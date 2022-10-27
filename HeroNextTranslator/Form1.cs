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
        private readonly OpenFileDialog _openFileDialog;
        private readonly FolderBrowserDialog _folderBrowserDialog;
        private string _translateSourcePath = string.Empty;
        private string _searchFolder = string.Empty;
        private string _heroRepoFolder = string.Empty;
        private TranslateOccurrance _currentTranslateOccurrence;
        private readonly BindingList<TranslateOccurrance> _occurrences = new();
        private LocalizationDictionary _translations;

        private readonly List<string> _includeFiles = new()
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

            _occurrences.Clear();

            var allFiles = Directory.GetFiles(_searchFolder, "*.*", SearchOption.AllDirectories)
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
            pgbProgress.Maximum = allFiles.Count();

            var tasks = allFiles.Select(GetAllOccurencesAsync);

            await Task.WhenAll(tasks);

            lbOccurances.DataSource = _occurrences;
            lbOccurances.DisplayMember = "DisplayName";
        }

        private async void btnStartSearch_ClickAsync(object sender, EventArgs e)
        {
            await SearchFolderPathAsync();
        }

        private void AddAllOccurrences(string content, string regex, FileInfo info)
        {
            var matches = Regex.Matches(content, regex);
            var count = matches.Count();

            for (var i = 0; i < count; i++)
            {
                var match = matches[i];

                foreach (var group in match.Groups.Values)
                {
                    AddQuotedOccurrences(group, info);
                    AddNameofWithDotOccurrences(group, info);
                }
            }
        }

        private void AddQuotedOccurrences(Capture group, FileInfo info)
        {
            var insideQuoteMatches = Regex.Matches(group.Value, "\"(.*?)\"");
            AddOccurrences(insideQuoteMatches.Count, insideQuoteMatches, info);
        }

        private void AddNameofWithDotOccurrences(Capture group, FileInfo info)
        {
            var matches = Regex.Matches(group.Value, "\\((\\w*?.*\\w*?)\\)");
            AddOccurrences(matches.Count, matches, info);
        }

        private void AddOccurrences(int groupCount, MatchCollection matches, FileInfo info)
        {
            for (var j = 0; j < groupCount; j++)
            {
                var insideQuoteMatch = matches[j];

                foreach (var text in insideQuoteMatch.Groups.Values)
                {
                    var key = text.Value.Replace('"', ' ').TrimEnd().TrimStart();
                    key = key.Replace("(", "").Replace(")","");

                    var parts = key.Split(".");
                    key = parts.Length > 0 ? parts.Last() : key;

                    if (_translations.Texts.Text.FirstOrDefault(x => x.Name == key) == null)
                    {
                        _occurrences.Add(new TranslateOccurrance
                        {
                            File = info,
                            Term = key,
                        });
                    }
                }
            }
        }

        private async Task GetAllOccurencesAsync(string file)
        {
            using(var reader = new StreamReader(file))
            {
                const string quotesExp = "L\\(\\\"(\\w*?)\\\"";
                const string nameofWithDot = "\\(*L\\(nameof\\((\\w*?.*\\w*?)\\)\\)";

                var content = await reader.ReadToEndAsync();
                var info = new FileInfo(file);

                AddAllOccurrences(content, quotesExp, info);
                AddAllOccurrences(content, nameofWithDot, info);
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

        private void lbOccurences_SelectedValueChanged(object sender, EventArgs e)
        {
            OnLbOccurrencesSelectChange(sender);
        }

        private void OnLbOccurrencesSelectChange(object sender)
        {
            if (sender is not ListBox { SelectedItem: TranslateOccurrance occurrance }) return;

            txtTranslationName.Text = occurrance.Term;
            txtTranslationValue.Text = occurrance.Term;
            _currentTranslateOccurrence = occurrance;
            lblSelectedFilePath.Text = occurrance.File.FullName;
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

            _occurrences.Where(x => x.Term == _currentTranslateOccurrence.Term)
                .ToList()
                .ForEach(i => _occurrences.Remove(i));

            txtTranslationName.Text = string.Empty;
            txtTranslationValue.Text = String.Empty;
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

        private void lbOccurances_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnLbOccurrencesSelectChange(sender);
        }
    }
}