using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadlyTradeOverhaul
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Mutex m_hMutex = new Mutex(true, "DeadlyCrushTradeOverhaulRenewalVersion", out bool bMutex);

            if (bMutex)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LauncherForm());

                m_hMutex.ReleaseMutex();
            }
            else
            {
                if (args == null)
                {
                    MSGForm frmMSG4 = new MSGForm();
                    frmMSG4.lbMsg.Text = "(already running.) Deadly Trade Overhaul 프로그램이 이미 실행중입니다.";
                    frmMSG4.ShowDialog();
                }
            }
        }
    }
}
