using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace POExileDirection
{
    public partial class OptimizerForm : Form
    {
        #region Class Global Variables & delegate
        private int _cachFileCNT = 0;
        private int _shaderFileCNT = 0;

        private string g_strUILang = String.Empty;
        private int resolution_height = 0;
        private int resolution_width = 0;

        private string g_strPOEPath = String.Empty;

        private Thread workerThread = null;
        private bool _workerThreadING = false;
        private bool _DIREXIST = true;
        private int cantFindDirCNT = 0;
        #endregion

        public OptimizerForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";

            Init_Controls();

            Get_Resolution();

            Get_POEPath();
        }

        private void Get_POEPath()
        {
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");

            if (!File.Exists(strINIPath))
            {
                g_strPOEPath = "Can't Find POE Path in DeadlyTrade Config File.";
                DeadlyLog4Net._log.Info($"{MethodBase.GetCurrentMethod().Name} : " + g_strPOEPath);
                lablePath.Text = g_strPOEPath;

                return;
            }

            if (g_strUILang != "UNKNOWN" && resolution_height != 0 && resolution_width != 0)
            {
                strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
                IniParser parser = new IniParser(strINIPath);

                try
                {
                    g_strPOEPath = parser.GetSetting("DIRECTIONHELPER", "POELOGPATH");

                    string[] wordsPOEPathfromConfig = g_strPOEPath.Split('\\');
                    g_strPOEPath = "";
                    for(int nIndex=0; nIndex< wordsPOEPathfromConfig.Length-2; nIndex++)
                        g_strPOEPath = g_strPOEPath + wordsPOEPathfromConfig[nIndex] + "\\";

                    lablePath.Text = g_strPOEPath;
                    btnStartCheck.Visible = true;
                }
                catch
                {
                    g_strPOEPath = "Can't Find POE Path in DeadlyTrade Config File.";
                    lablePath.Text = g_strPOEPath;
                }
            }
        }

        private void Get_Resolution()
        {
            // Get Addon Data & Pesonal Setting ( From My Games - Path of Exile )               
            String strPathPOEConifg = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            strPathPOEConifg = strPathPOEConifg + "\\My Games\\Path of Exile\\production_Config.ini";
            IniParser parser = new IniParser(strPathPOEConifg);

            try
            {
                string strLanguage = parser.GetSetting("LANGUAGE", "language");
                if (strLanguage.Equals("ko-KR", StringComparison.OrdinalIgnoreCase))
                    g_strUILang = "KOR";
                else if (strLanguage.Equals("en", StringComparison.OrdinalIgnoreCase))
                    g_strUILang = "ENG";
                else
                    g_strUILang = "UNKNOWN";

                if (g_strUILang == "UNKNOWN")
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.btmConfirm.Visible = false;
                    frmMSG.btnENG.Visible = true;
                    frmMSG.btnKOR.Visible = true;
                    frmMSG.lbMsg.Text = "Can't find POE UI Configuration. What is your OPTION-UI Languge in POE?";
                    DialogResult dr = frmMSG.ShowDialog();
                    if (dr == DialogResult.Yes)
                        g_strUILang = "KOR";
                    else
                        g_strUILang = "ENG";
                }

                resolution_height = Convert.ToInt32(parser.GetSetting("DISPLAY", "resolution_height"));
                resolution_width = Convert.ToInt32(parser.GetSetting("DISPLAY", "resolution_width"));
            }
            catch(Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                g_strUILang = "UNKNOWN";
                resolution_height = 0;
                resolution_width = 0;
            }
        }

        private void Init_Controls()
        {
            xuiGaugeMinimapCache.Percentage = 0;
            xuiGaugeLogFileSize.Percentage =0;

            labelMinimapCacheInform.Text = "";
            labelShaderFileInform.Text = "";
        }

        private void CheckCacheAndLogFile()
        {
            DateTime dtCurrent = DateTime.Now;
            TimeSpan ts;

            try
            {
                // MiniMap Cache
                String strMyGamesPOEDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                strMyGamesPOEDir = strMyGamesPOEDir + "\\My Games\\Path of Exile\\Minimap";

                if (!Directory.Exists(strMyGamesPOEDir))
                {
                    _DIREXIST = false;
                    this.workerThread.Abort();
                }
                else
                    _DIREXIST = true;

                DirectoryInfo di = new DirectoryInfo(strMyGamesPOEDir);

                foreach (FileInfo file in di.EnumerateFiles())
                {
                    ts = dtCurrent - file.LastWriteTime;
                    if (ts.Days > 3)
                        _cachFileCNT += 1;
                    this.Invoke(this.updateStatusDelegate);
                }

                cantFindDirCNT = 0;

                // ShaderCache
                strMyGamesPOEDir = g_strPOEPath + "ShaderCacheD3D11";

                if (Directory.Exists(strMyGamesPOEDir))
                {

                    DirectoryInfo di2 = new DirectoryInfo(strMyGamesPOEDir);
                    foreach (FileInfo file in di2.EnumerateFiles())
                    {
                        ts = dtCurrent - file.LastWriteTime;
                        if (ts.Days > 3)
                            _shaderFileCNT += 1;
                        this.Invoke(this.updateStatusDelegate);
                    }

                    DirectoryInfo[] subDirs2 = di2.GetDirectories();
                    if (subDirs2.Length > 0)
                    {
                        foreach (DirectoryInfo subDirInfo in subDirs2)
                        {
                            // Console.WriteLine("   " + subDirInfo.Name);
                            if (subDirInfo != null)
                            {
                                FileInfo[] subFiles = subDirInfo.GetFiles();
                                if (subFiles.Length > 0)
                                {
                                    foreach (FileInfo subFile in subFiles)
                                    {
                                        ts = dtCurrent - subFile.LastWriteTime;
                                        if (ts.Days > 3)
                                            //Console.WriteLine("   " + subFile.Name + " (" + subFile.Length + " bytes)");
                                            _shaderFileCNT += 1;
                                        this.Invoke(this.updateStatusDelegate);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    cantFindDirCNT++;
                }

                // ShaderCache_GI
                strMyGamesPOEDir = g_strPOEPath + "ShaderCacheD3D11_GI";

                if (Directory.Exists(strMyGamesPOEDir))
                {

                    DirectoryInfo di3 = new DirectoryInfo(strMyGamesPOEDir);
                    foreach (FileInfo file in di3.EnumerateFiles())
                    {
                        ts = dtCurrent - file.LastWriteTime;
                        if (ts.Days > 3)
                            _shaderFileCNT += 1;
                        this.Invoke(this.updateStatusDelegate);
                    }

                    DirectoryInfo[] subDirs3 = di3.GetDirectories();
                    if (subDirs3.Length > 0)
                    {
                        foreach (DirectoryInfo subDirInfo in subDirs3)
                        {
                            // Console.WriteLine("   " + subDirInfo.Name);
                            if (subDirInfo != null)
                            {
                                FileInfo[] subFiles = subDirInfo.GetFiles();
                                if (subFiles.Length > 0)
                                {
                                    foreach (FileInfo subFile in subFiles)
                                    {
                                        //Console.WriteLine("   " + subFile.Name + " (" + subFile.Length + " bytes)");
                                        ts = dtCurrent - subFile.LastWriteTime;
                                        if (ts.Days > 3)
                                            _shaderFileCNT += 1;
                                        this.Invoke(this.updateStatusDelegate);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    cantFindDirCNT++;
                }

                if (cantFindDirCNT >= 2)
                    _DIREXIST = false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }

            this.Invoke(this.updateStatusDelegate);
            _workerThreadING = false;
            this.workerThread.Abort();
        }

        private void btnStartCheck_Click(object sender, EventArgs e)
        {
            this.workerThread = new Thread(new ThreadStart(this.CheckCacheAndLogFile));
            this.workerThread.Start();
            _workerThreadING = true;
        }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            string strPath = String.Empty;
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
            DialogResult dr = dlgFolder.ShowDialog();
            if (dr == DialogResult.OK)
            {
                g_strPOEPath = dlgFolder.SelectedPath;
                string[] wordsPOEPathfromConfig = g_strPOEPath.Split('\\');
                g_strPOEPath = "";
                foreach (var words in wordsPOEPathfromConfig)
                    g_strPOEPath = g_strPOEPath + words + "\\";

                lablePath.Text = g_strPOEPath;
                btnStartCheck.Visible = true;
            }
        }

        private void btnCleanMinimapCache_Click(object sender, EventArgs e)
        {
            this.workerThread = new Thread(new ThreadStart(this.CleanMinimapFile));
            this.workerThread.Start();
            _workerThreadING = true;
        }

        private void CleanMinimapFile()
        {
            DateTime dtCurrent = DateTime.Now;
            TimeSpan ts;

            try
            {
                String strMyGamesPOEDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                strMyGamesPOEDir = strMyGamesPOEDir + "\\My Games\\Path of Exile\\Minimap";

                DirectoryInfo di = new DirectoryInfo(strMyGamesPOEDir);

                foreach (FileInfo file in di.EnumerateFiles())
                {
                    ts = dtCurrent - file.LastWriteTime;
                    if (ts.Days > 3)
                        file.Delete();
                    this.Invoke(this.updateStatusDelegate);
                }
                foreach (DirectoryInfo dir in di.EnumerateDirectories())
                {
                    dir.Delete(true);
                    this.Invoke(this.updateStatusDelegate);
                }
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }

            _cachFileCNT = 0;
            this.Invoke(this.updateStatusDelegate);

            _workerThreadING = false;
            this.workerThread.Abort();
        }

        private void btnCleanShaderCacheFile_Click(object sender, EventArgs e)
        {
            this.workerThread = new Thread(new ThreadStart(this.CleanShaderFile));
            this.workerThread.Start();
            _workerThreadING = true;
        }

        private void CleanShaderFile()
        {
            DateTime dtCurrent = DateTime.Now;
            TimeSpan ts;

            try
            {
                string strShaderCacheDir = g_strPOEPath + "ShaderCacheD3D11";

                DirectoryInfo di = new DirectoryInfo(strShaderCacheDir);

                foreach (FileInfo file in di.EnumerateFiles())
                {
                    ts = dtCurrent - file.LastWriteTime;
                    if (ts.Days > 3)
                        file.Delete();
                    this.Invoke(this.updateStatusDelegate);
                }
                foreach (DirectoryInfo dir in di.EnumerateDirectories())
                {
                    ts = dtCurrent - dir.LastWriteTime;
                    if (ts.Days > 3)
                        dir.Delete(true);
                    this.Invoke(this.updateStatusDelegate);
                }

                strShaderCacheDir = g_strPOEPath + "ShaderCacheD3D11_GI";

                DirectoryInfo di2 = new DirectoryInfo(strShaderCacheDir);

                foreach (FileInfo file in di2.EnumerateFiles())
                {
                    ts = dtCurrent - file.LastWriteTime;
                    if (ts.Days > 3)
                        file.Delete();
                    this.Invoke(this.updateStatusDelegate);
                }
                foreach (DirectoryInfo dir in di2.EnumerateDirectories())
                {
                    ts = dtCurrent - dir.LastWriteTime;
                    if (ts.Days > 3)
                        dir.Delete(true);
                    this.Invoke(this.updateStatusDelegate);
                }
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }

            _shaderFileCNT = 0;
            this.Invoke(this.updateStatusDelegate);

            _workerThreadING = false;
            this.workerThread.Abort();
        }

        private delegate void UpdateStatusDelegate();
        private UpdateStatusDelegate updateStatusDelegate = null;

        private void OptimizerForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            Left = 0;
            Top = 0;
            Visible = true;

            this.updateStatusDelegate = new UpdateStatusDelegate(this.UpdateStatus);
        }

        private void UpdateStatus()
        {
            if (!_DIREXIST)
            {
                g_strPOEPath = "Can't Find POE Path in DeadlyTrade Config File.";
                lablePath.Text = g_strPOEPath;
            }
            else
            {
                lablePath.Text = g_strPOEPath;
            }

            if (cantFindDirCNT >= 2)
            {
                labelMinimapCacheInform.Visible = false;
                labelShaderFileInform.Visible = false;
            }
            else
            {
                labelMinimapCacheInform.Visible = true;
                labelShaderFileInform.Visible = true;
            }

            xuiGaugeMinimapCache.Percentage = _cachFileCNT;
            xuiGaugeLogFileSize.Percentage = _shaderFileCNT;

            labelMinimapCacheInform.Text = "Old Minimap Cache Files Count : " + _cachFileCNT;
            labelShaderFileInform.Text = "Old ShaderCache Files Count : " + _shaderFileCNT;

            if (_cachFileCNT > 0)
                btnCleanMinimapCache.Visible = true;
            else
                btnCleanMinimapCache.Visible = false;
            if (_shaderFileCNT > 0)
                btnCleanShaderCacheFile.Visible = true;
            else
                btnCleanShaderCacheFile.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
