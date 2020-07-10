using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Pro_0_Mylife
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ProgramStart();

        }
        static void ProgramStart()
        {
            OracleDBManager dbManager = new OracleDBManager();
            if (dbManager.GetConnection() == false)
            {
                MessageBox.Show("데이터베이스 접속 연결 실패!!!!");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_main());
        }
    }
}
