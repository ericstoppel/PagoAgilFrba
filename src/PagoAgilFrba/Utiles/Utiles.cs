using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Utiles
{
    class Utiles
    {
        public static Boolean handleError(DataTable resultadoProcedure) {
            if (resultadoProcedure.Rows.Count > 0 && resultadoProcedure.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(resultadoProcedure.Rows[0].ItemArray[1].ToString());
                return false;
            }
            return true;
        }
    }
}
