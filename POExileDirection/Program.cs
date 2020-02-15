using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POExileDirection
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex m_hMutex = new Mutex(true, "POExileDirectionDeadlyCrush", out bool bMutex);

            if (bMutex)
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ControlForm());

                m_hMutex.ReleaseMutex();
            }
            else
            {
                MSGForm frmMSG4 = new MSGForm();
                frmMSG4.lbMsg.Text = "POE Direction Helper가 이미 실행중입니다.";
                frmMSG4.ShowDialog();
            }
        }
    }
}
