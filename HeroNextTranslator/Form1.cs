using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace HeroNextTranslator
{
    public partial class Form1 : Form
    {
        readonly OpenFileDialog _openFileDialog;
        readonly FolderBrowserDialog _folderBrowserDialog;
        string _translateSourcePath = string.Empty;
        string _searchFolder = string.Empty;
        string _heroRepoFolder = string.Empty;
        TranslateOccurrance _currentTranslateOccurrance;
        BindingList<TranslateOccurrance> _occurrances = new BindingList<TranslateOccurrance>();
        LocalizationDictionary _translations = null;

        List<string> _includeFiles = new List<string>
        {
            ".cs",
            ".cshtml",
        };

        public Form1()
        {
            _openFileDialog = new OpenFileDialog()
            {
                Multiselect = false,
                Filter = "XML Files|*.xml"
            };
            _folderBrowserDialog = new FolderBrowserDialog();

            InitializeComponent();
        }

        private void btnSearchTranslateSource_Click(object sender, EventArgs e)
        {
            _openFileDialog.InitialDirectory = string.IsNullOrEmpty(_heroRepoFolder) ? "" : _heroRepoFolder;
            _openFileDialog.ShowDialog();

            if (string.IsNullOrEmpty(_openFileDialog.FileName))
                return;

            SetResource(_openFileDialog.FileName);
            LoadXML();
        }

        private void btnSelectSearchFolder_Click(object sender, EventArgs e)
        {
            _folderBrowserDialog.InitialDirectory = string.IsNullOrEmpty(_heroRepoFolder) ? "" : _heroRepoFolder;
            _folderBrowserDialog.ShowDialog();

            if (string.IsNullOrEmpty(_folderBrowserDialog.SelectedPath))
                return;

            _searchFolder = _folderBrowserDialog.SelectedPath;
            lblSearchFolderPath.Text = _searchFolder;
        }

        private async Task SearchFolderPathAsync()
        {
            if (string.IsNullOrEmpty(_searchFolder))
                return;

            _occurrances.Clear();

            string[] allfiles = Directory.GetFiles(_searchFolder, "*.*", SearchOption.AllDirectories)
                .Where(x =>
                {
                    var contains = false;
                    _includeFiles.ForEach(i => 
                    {
                        if (x.EndsWith(i))
                            contains = true;
                    });
                    return contains;
                })
                .ToArray();

            pgbProgress.Value = 0;
            pgbProgress.Maximum = allfiles.Count();

            var tasks = allfiles.Select(file => GetAllOccurancesAsync(file));

            await Task.WhenAll(tasks);

            lbOccurances.DataSource = _occurrances;
            lbOccurances.DisplayMember = "DisplayName";
        }

        private async void btnStartSearch_ClickAsync(object sender, EventArgs e)
        {
            await SearchFolderPathAsync();
        }

        private async Task GetAllOccurancesAsync(string file)
        {
            using(var reader = new StreamReader(file))
            {
                var content = await reader.ReadToEndAsync();
                MatchCollection matches = Regex.Matches(content, "L\\(\"(\\w*?)\"");
                var count = matches.Count();
                FileInfo info = new FileInfo(file);

                for (int i = 0; i < count; i++)
                {
                    var match = matches[i];

                    foreach(var group in match.Groups.Values)
                    {
                        MatchCollection insideQuoteMatches = Regex.Matches(group.Value, "\"(.*?)\"");
                        var insideCount = insideQuoteMatches.Count();

                        for (int j = 0; j < insideCount; j++)
                        {
                            var insideQuoteMatche = insideQuoteMatches[j];

                            foreach (var text in insideQuoteMatche.Groups.Values)
                            {
                                var key = text.Value.Replace('"', ' ').TrimEnd().TrimStart();

                                if (_translations.Texts.Text.FirstOrDefault(x => x.Name == key) == null)
                                {
                                    _occurrances.Add(new TranslateOccurrance
                                    {
                                        File = info,
                                        Term = key,
                                    });
                                }
                            }
                        }
                    }
                }
            }

            pgbProgress.Value++;
        }

        private void LoadXML()
        {
            if (string.IsNullOrEmpty(_translateSourcePath)) return;

            using (var reader = new StreamReader(_translateSourcePath))
            {
                var content = reader.ReadToEnd();

                using (StringReader textReader = new StringReader(content))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(LocalizationDictionary));
                    _translations = (LocalizationDictionary)xmlSerializer.Deserialize(textReader);

                    lblTotalTranslations.Text = _translations?.Texts.Text.Count().ToString() ?? "0";
                }
                
            }
        }

        private void lbOccurances_SelectedValueChanged(object sender, EventArgs e)
        {
            if(sender is ListBox lb && lb.SelectedItem is TranslateOccurrance occurrance)
            {
                txtTranslationName.Text = occurrance.Term;
                txtTranslationValue.Text = occurrance.Term;
                _currentTranslateOccurrance = occurrance;
                lblSelectedFilePath.Text = occurrance.File.FullName;
            }
        }

        private void btnSave_ClickAsync(object sender, EventArgs e)
        {
            var translation = new Text()
            {
                Name = txtTranslationName.Text,
                Content = txtTranslationValue.Text
            };
            _translations.Texts.Text.Add(translation);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LocalizationDictionary));

            using (StreamWriter writer = new StreamWriter(_translateSourcePath))
            using (var xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings { Indent = true }))
            {
                xmlSerializer.Serialize(xmlWriter, _translations);
            }

            _occurrances.Where(x => x.Term == _currentTranslateOccurrance.Term)
                .ToList()
                .ForEach(i => _occurrances.Remove(i));
        }

        private void SetResource(string path)
        {
            if (!File.Exists(path))
                return;

            _translateSourcePath = path;
            lblTranslateSourcePath.Text = path;
        }

        private void SetSearchFolder(string path)
        {
            if (!Directory.Exists(path))
                return;

            _searchFolder = path;
            lblSearchFolderPath.Text = path;
        }

        private async void btnSearchHeroRepoFolder_Click(object sender, EventArgs e)
        {
            _folderBrowserDialog.ShowDialog();
            if (string.IsNullOrEmpty(_folderBrowserDialog.SelectedPath))
                return;

            _heroRepoFolder = _folderBrowserDialog.SelectedPath;
            lblHeroRepoFolder.Text = _heroRepoFolder;
            
            SetResource(Path.Join(_heroRepoFolder, "\\src\\HeroNextWtec.Core\\Localization\\SourceFiles\\HeroNextWtec.xml"));
            SetSearchFolder(Path.Join(_heroRepoFolder, "\\src\\HeroNextWtec.Web.Mvc"));
            LoadXML();
            await SearchFolderPathAsync();
        }

        private void btnViewFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblSelectedFilePath.Text))
                return;

            Process.Start("explorer.exe", lblSelectedFilePath.Text);
        }
    }
}