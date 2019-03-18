using System;
using System.Collections.Generic;
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
            //fN.Dock = DockStyle.Fill;
            fN.Size = pnl.Size;
            pnl.Controls.Add(fN);
            pnl.Tag = fN;
            fN.Show();
        }
    }
}

