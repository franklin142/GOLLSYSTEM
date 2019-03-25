using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLLSYSTEM.Validation
{
    public class FormManager
    {
        public void LoadForm(Panel pnl, Form FormOpening)
        {
            if (pnl.Controls.Count > 0)
                pnl.Controls.RemoveAt(0);
            Form fN = FormOpening as Form;
            fN.TopLevel = false;
            fN.Size = pnl.Size;
            pnl.Controls.Add(fN);
            pnl.Tag = fN;
            fN.Show();
        }
        public void writeException(string folderName, string fileName, Exception ex,string extra)
        {
            if (!Directory.Exists(folderName))
            {
                DirectoryInfo di = Directory.CreateDirectory(folderName);
                if (!System.IO.File.Exists(folderName + "\\" + fileName))
                {
                    using (StreamWriter mylogs = File.AppendText(folderName + "\\" + fileName))         //se crea el archivo
                    {
                        string strDate = Convert.ToDateTime(DateTime.Now).ToString("dd MMMM yyyy");
                        mylogs.WriteLine("///////////////////////////////////////////////////////////////");
                        mylogs.WriteLine("//\t\t\t" + strDate + "\t\t\t    //");
                        mylogs.WriteLine("/////////////////////////////////////////////////////////////");
                        mylogs.WriteLine(ex.ToString());
                        mylogs.WriteLine("Extra:");
                        mylogs.WriteLine(extra);
                        mylogs.WriteLine("");
                        mylogs.Close();
                    }
                }
                else
                {
                    using (StreamWriter file = new StreamWriter(folderName + "\\" + fileName, true))
                    {
                        string strDate = Convert.ToDateTime(DateTime.Now).ToString("dd MMMM yyyy");
                        file.WriteLine("///////////////////////////////////////////////////////////////");
                        file.WriteLine("//\t\t\t" + strDate + "\t\t\t    //");
                        file.WriteLine("/////////////////////////////////////////////////////////////");
                        file.WriteLine(ex.ToString());
                        file.WriteLine("Extra:");
                        file.WriteLine(extra);
                        file.WriteLine(""); file.Close();
                    }
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter(folderName + "\\" + fileName, true))
                {
                    string strDate = Convert.ToDateTime(DateTime.Now).ToString("dd MMMM yyyy");
                    file.WriteLine("///////////////////////////////////////////////////////////////");
                    file.WriteLine("//\t\t\t" + strDate + "\t\t\t    //");
                    file.WriteLine("/////////////////////////////////////////////////////////////");
                    file.WriteLine(ex.ToString());
                    file.WriteLine("Extra:");
                    file.WriteLine(extra);
                    file.WriteLine(""); file.Close();

                    file.Close();
                }
            }
        }
    }
}

