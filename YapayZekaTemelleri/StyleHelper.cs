using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YapayZekaTemelleri
{
    public static class StyleHelper
    {
        // bu sınıfı yazma amacım diğer sayfalardaki tasarımları buradan yonetebilmek.

        public static void ApplyButtonStyles(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.SteelBlue;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }

                // Eğer kontrolün içinde başka alt kontroller varsa onlara da uygula
                if (control.HasChildren)
                {
                    ApplyButtonStyles(control); // Recursive çağrı
                }
            }
        }

        public static void ApplyLabelStyles(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label label && label.Name != "label1")
                {
                    label.ForeColor = Color.White;
                    label.Font = new Font("Times New Roman", 10F, FontStyle.Regular);
                }

                // Alt kontroller varsa onlara da uygula (örneğin panel içindekiler)
                if (control.HasChildren)
                {
                    ApplyLabelStyles(control); // Rekürsif çağrı
                }

            }
        }

        

    }
}
