using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PranitMeherProject3
{
    public partial class TableEmpCoop : Form
    {
        Employment emp;
        string whichData;
        string title;
        public TableEmpCoop(Employment emp, string whichData)
        {
            this.emp = emp;
            this.whichData = whichData;

            InitializeComponent();

            if(whichData == "coop")
            {
                title = emp.coopTable.title;
                dgv_coop.Visible = true;

                loadCoopTable();
            }
            else
            {
                title = emp.employmentTable.title;
                dgv_emp.Visible = true;
                loadEmploymentTable();
            }

            lbl_title.Text = title;
        }

        private void loadEmploymentTable()
        {
           // Adding data to employment table
           for(int i = 0; i < emp.employmentTable.professionalEmploymentInformation.Count; i++)
            {
                ProfessionalEmploymentInformation data = emp.employmentTable.professionalEmploymentInformation[i];
                dgv_emp.Rows.Add(data.employer, data.degree, data.city, data.title, data.startDate);
            }
        }

        private void loadCoopTable()
        {
            // Adding data to Coop table
            for (int i = 0; i < emp.coopTable.coopInformation.Count; i++)
            {
                CoopInformation data = emp.coopTable.coopInformation[i];
                dgv_coop.Rows.Add(data.employer, data.degree, data.city, data.term);
            }
        }

        private void TableEmpCoop_Load(object sender, EventArgs e)
        {
            
        }
    }
}
