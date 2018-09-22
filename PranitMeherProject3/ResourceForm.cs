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
    public partial class ResourceForm : Form
    {
        Resources resource;
        public ResourceForm(Resources resource, string whichResource)
        {
            InitializeComponent();

            if(whichResource == "Study Abroad")
            {
                this.resource = resource;
                makeStudyAbroad();
                pnl_stdy_ab.Visible = true;
            }
            else if (whichResource == "Advising")
            {
                this.resource = resource;
                makeStudentServices();
                pnl_std_serv.Visible = true;
            }
            else if (whichResource == resource.tutorsAndLabInformation.title)
            {
                this.resource = resource;
                makeTutorsAndLabs();
                pnl_tut_lab.Visible = true;
            }
            else if (whichResource == resource.studentAmbassadors.title)
            {
                this.resource = resource;
                makeStudentAmbassadors();
                pnl_std_amb.Visible = true;
            }
            else if (whichResource == "Forms")
            {
                this.resource = resource;
                makeForms();
                pnl_forms.Visible = true;
            }
            else if (whichResource == resource.coopEnrollment.title)
            {
                this.resource = resource;
                makeCoopEnrollment();
                pnl_coop.Visible = true;
            }
        }

        #region Coop
        private void makeCoopEnrollment()
        {
            // Link
            Label linklb = new Label();
            linklb.Text = "RIT Job Zone Link";
            linklb.Dock = DockStyle.Top;
            linklb.ForeColor = Color.Orange;
            linklb.Click += (s, p) => makeLink(s, p, resource.coopEnrollment.RITJobZoneGuidelink);
            linklb.Cursor = Cursors.Hand;
            linklb.TextAlign = ContentAlignment.MiddleCenter;
            pnl_coop.Controls.Add(linklb);

            // Info
            for (int i = resource.coopEnrollment.enrollmentInformationContent.Count - 1; i >= 0; i--)
            {
                // Description
                Label lbl_desc = new Label();
                //lbl_desc.Height = 150;
                lbl_desc.AutoSize = true;
                lbl_desc.MaximumSize = new Size(650, 0);
                lbl_desc.Text = resource.coopEnrollment.enrollmentInformationContent[i].description;
                lbl_desc.Font = new Font("calibri", 10);
                lbl_desc.Dock = DockStyle.Top;
                lbl_desc.TextAlign = ContentAlignment.MiddleCenter;
                pnl_coop.Controls.Add(lbl_desc);

                // Title
                Label lbl_title = new Label();
                lbl_title.Height = 30;
                lbl_title.Text = resource.coopEnrollment.enrollmentInformationContent[i].title;
                lbl_title.Font = new Font("calibri", 13, FontStyle.Bold);
                lbl_title.Dock = DockStyle.Top;
                lbl_title.ForeColor = Color.Orange;
                lbl_title.TextAlign = ContentAlignment.MiddleCenter;
                pnl_coop.Controls.Add(lbl_title);

            }
        }
        #endregion

        #region Forms
        private void makeForms()
        {

            for (int i = resource.forms.undergraduateForms.Count - 1; i >= 0; i--)
            {
                Label linklb = new Label();
                linklb.Text = resource.forms.undergraduateForms[i].formName + "(Some Links may not work as the links don't exist anymore)";
                linklb.Dock = DockStyle.Top;
                linklb.ForeColor = Color.Orange;
                linklb.Click += (s, p) => makeLink(s, p, "www.ist.rit.edu/"+resource.forms.undergraduateForms[i].href);
                linklb.Cursor = Cursors.Hand;
                linklb.TextAlign = ContentAlignment.MiddleCenter;
                pnl_forms.Controls.Add(linklb);

            }

            // Title UnderGraduate Forms
            Label lbl_title = new Label();
            lbl_title.Height = 30;
            lbl_title.Text = "Undergraduate Forms";
            lbl_title.Font = new Font("calibri", 13, FontStyle.Bold);
            lbl_title.Dock = DockStyle.Top;
            lbl_title.TextAlign = ContentAlignment.MiddleCenter;
            pnl_forms.Controls.Add(lbl_title);

            for (int i = resource.forms.graduateForms.Count - 1; i >= 0; i--)
            {
                Label linklb = new Label();
                linklb.Text = resource.forms.graduateForms[i].formName + "(Some Links may not work as the links don't exist anymore)";
                linklb.Dock = DockStyle.Top;
                linklb.Click += (s, p) => makeLink(s, p, "www.ist.rit.edu/" + resource.forms.graduateForms[i].href);
                linklb.Cursor = Cursors.Hand;
                linklb.ForeColor = Color.Orange;
                linklb.TextAlign = ContentAlignment.MiddleCenter;
                pnl_forms.Controls.Add(linklb);

            }

                // Title Graduate Forms
                Label lbl_title_ug = new Label();
            lbl_title_ug.Height = 30;
            lbl_title_ug.Text = "Graduate Forms";
            lbl_title_ug.Font = new Font("calibri", 13, FontStyle.Bold);
            lbl_title_ug.Dock = DockStyle.Top;
            lbl_title_ug.TextAlign = ContentAlignment.MiddleCenter;
            pnl_forms.Controls.Add(lbl_title_ug);
        }
        #endregion

        #region Student Ambassadors
        private void makeStudentAmbassadors()
        {
            // Note
            // Description
            Label lbl_note = new Label();
            lbl_note.Height = 40;
            lbl_note.ForeColor = Color.Red;
            lbl_note.Text = resource.studentAmbassadors.note;
            lbl_note.Font = new Font("calibri", 10);
            lbl_note.Dock = DockStyle.Top;
            lbl_note.TextAlign = ContentAlignment.MiddleCenter;
            pnl_std_amb.Controls.Add(lbl_note);

            // Application link
            LinkLabel linklb = new LinkLabel();
            linklb.Text = "Click here for the Application form";
            linklb.Dock = DockStyle.Top;
            linklb.Click += (s, p) => makeLink(s, p, resource.studentAmbassadors.applicationFormLink);
            linklb.Cursor = Cursors.Hand;
            linklb.TextAlign = ContentAlignment.MiddleCenter;
            pnl_std_amb.Controls.Add(linklb);

            // SubSection Content
            for (int i = resource.studentAmbassadors.subSectionContent.Count -1; i >= 0; i--)
            {
                // Description
                Label lbl_desc = new Label();
                //lbl_desc.Height = 150;
                lbl_desc.AutoSize = true;
                lbl_desc.MaximumSize = new Size (650,0);
                lbl_desc.Text = resource.studentAmbassadors.subSectionContent[i].description;
                lbl_desc.Font = new Font("calibri", 10);
                lbl_desc.Dock = DockStyle.Top;
                lbl_desc.TextAlign = ContentAlignment.MiddleCenter;
                pnl_std_amb.Controls.Add(lbl_desc);

                // Title
                Label lbl_title = new Label();
                lbl_title.Height = 30;
                lbl_title.Text = resource.studentAmbassadors.subSectionContent[i].title;
                lbl_title.Font = new Font("calibri", 13, FontStyle.Bold);
                lbl_title.Dock = DockStyle.Top;
                lbl_title.TextAlign = ContentAlignment.MiddleCenter;
                pnl_std_amb.Controls.Add(lbl_title);

            }


            // Image
            PictureBox pb = new PictureBox();
            pb.Height = 400;
            //pb.Width = 200;
            pb.Load(resource.studentAmbassadors.ambassadorsImageSource);
            pb.Dock = DockStyle.Top;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pnl_std_amb.Controls.Add(pb);

            // Student Ambassadors label
            Label lbl_std_amb_title = new Label();
            lbl_std_amb_title.Height = 30;
            lbl_std_amb_title.Text = resource.studentAmbassadors.title;
            lbl_std_amb_title.Font = new Font("calibri", 16, FontStyle.Bold);
            lbl_std_amb_title.Dock = DockStyle.Top;
            lbl_std_amb_title.TextAlign = ContentAlignment.MiddleCenter;
            pnl_std_amb.Controls.Add(lbl_std_amb_title);
        }

        #endregion

        #region Tutors and Labs
        private void makeTutorsAndLabs()
        {
            // Tutors and Labs Link
            Label lbl_tut_lab_link = new Label();
            lbl_tut_lab_link.Height = 30;
            lbl_tut_lab_link.Text = resource.tutorsAndLabInformation.title;
            lbl_tut_lab_link.Font = new Font("calibri", 10);
            lbl_tut_lab_link.Dock = DockStyle.Top;
            lbl_tut_lab_link.TextAlign = ContentAlignment.MiddleCenter;
            lbl_tut_lab_link.Click += (s, p) => makeLink(s, p, resource.tutorsAndLabInformation.tutoringLabHoursLink);
            lbl_tut_lab_link.Cursor = Cursors.Hand;
            pnl_tut_lab.Controls.Add(lbl_tut_lab_link);

            // Tutors and Labs Desc
            Label lbl_tut_lab_desc = new Label();
            lbl_tut_lab_desc.Height = 200;
            lbl_tut_lab_desc.Text = resource.tutorsAndLabInformation.description;
            lbl_tut_lab_desc.Font = new Font("calibri", 10);
            lbl_tut_lab_desc.Dock = DockStyle.Top;
            lbl_tut_lab_desc.TextAlign = ContentAlignment.MiddleCenter;
            pnl_tut_lab.Controls.Add(lbl_tut_lab_desc);

            // Tutors and Labs label
            Label lbl_tut_lab = new Label();
            lbl_tut_lab.Height = 30;
            lbl_tut_lab.Text = resource.tutorsAndLabInformation.title;
            lbl_tut_lab.Font = new Font("calibri", 14, FontStyle.Bold);
            lbl_tut_lab.Dock = DockStyle.Top;
            lbl_tut_lab.TextAlign = ContentAlignment.MiddleCenter;
            pnl_tut_lab.Controls.Add(lbl_tut_lab);
        }

        #endregion

        #region Student Services
        private void makeStudentServices()
        {
            // creating content for Student Services
            lbl_std_serv_title.Text = resource.title;


            #region IST Minor
            // IST Minor INFO
            for (int i = 0; i < resource.studentServices.istMinorAdvising.minorAdvisorInformation.Count; i++)
            {
                //Empty Space
                Label empty = new Label();
                empty.Height = 70;
                empty.Dock = DockStyle.Top;
                pnl_std_serv_details.Controls.Add(empty);

                //Email ID
                Label email = new Label();
                email.Height = 30;
                email.Text = "Email: " + resource.studentServices.istMinorAdvising.minorAdvisorInformation[i].email;
                email.Font = new Font("calibri", 10);
                email.Dock = DockStyle.Top;
                email.TextAlign = ContentAlignment.MiddleCenter;
                email.Click += makeEmail;
                email.Cursor = Cursors.Hand;
                pnl_std_serv_details.Controls.Add(email);

                //Advisor
                Label adv = new Label();
                adv.Height = 30;
                adv.Text = "Department: " + resource.studentServices.istMinorAdvising.minorAdvisorInformation[i].advisor;
                adv.Font = new Font("calibri", 10);
                adv.Dock = DockStyle.Top;
                adv.TextAlign = ContentAlignment.MiddleCenter;
                pnl_std_serv_details.Controls.Add(adv);

                //Title
                Label title = new Label();
                title.Height = 30;
                title.Text = "Title: " + resource.studentServices.istMinorAdvising.minorAdvisorInformation[i].title;
                title.Font = new Font("calibri", 10);
                title.Dock = DockStyle.Top;
                title.TextAlign = ContentAlignment.MiddleCenter;
                pnl_std_serv_details.Controls.Add(title);

            }

            // IST Minor Advising
            Label lbl_std_ser_istMinor_title = new Label();
            lbl_std_ser_istMinor_title.Height = 30;
            lbl_std_ser_istMinor_title.Text = resource.studentServices.istMinorAdvising.title;
            lbl_std_ser_istMinor_title.Font = new Font("calibri", 14, FontStyle.Bold);
            lbl_std_ser_istMinor_title.Dock = DockStyle.Top;
            lbl_std_ser_istMinor_title.TextAlign = ContentAlignment.MiddleCenter;
            pnl_std_serv_details.Controls.Add(lbl_std_ser_istMinor_title);


            #endregion

            #region Faculty Advisor

            // Faculty Advisor Description
            Label lbl_std_ser_fac_ad_desc = new Label();
            lbl_std_ser_fac_ad_desc.Height = 200;
            lbl_std_ser_fac_ad_desc.Text = resource.studentServices.facultyAdvisors.description;
            lbl_std_ser_fac_ad_desc.Font = new Font("calibri", 11);
            lbl_std_ser_fac_ad_desc.Dock = DockStyle.Top;
            lbl_std_ser_fac_ad_desc.TextAlign = ContentAlignment.MiddleCenter;
            pnl_std_serv_details.Controls.Add(lbl_std_ser_fac_ad_desc);

            // Faculty Advisor
            Label lbl_std_ser_fac_ad_title = new Label();
            lbl_std_ser_fac_ad_title.Height = 30;
            lbl_std_ser_fac_ad_title.Text = resource.studentServices.facultyAdvisors.title;
            lbl_std_ser_fac_ad_title.Font = new Font("calibri", 14, FontStyle.Bold);
            lbl_std_ser_fac_ad_title.Dock = DockStyle.Top;
            lbl_std_ser_fac_ad_title.TextAlign = ContentAlignment.MiddleCenter;
            pnl_std_serv_details.Controls.Add(lbl_std_ser_fac_ad_title);

            #endregion

            #region Professional Advising
            // Professional Info
            for (int i = 0; i < resource.studentServices.professonalAdvisors.advisorInformation.Count; i++)
            {
                //Empty Space
                Label empty = new Label();
                empty.Height = 70;
                empty.Dock = DockStyle.Top;
                pnl_std_serv_details.Controls.Add(empty);


                //Email ID
                Label email = new Label();
                email.Height = 30;
                email.Text = "Email: " + resource.studentServices.professonalAdvisors.advisorInformation[i].email;
                email.Font = new Font("calibri", 10);
                email.Dock = DockStyle.Top;
                email.TextAlign = ContentAlignment.MiddleCenter;
                email.Click += makeEmail;
                email.Cursor = Cursors.Hand;
                pnl_std_serv_details.Controls.Add(email);

                //Department
                Label dept = new Label();
                dept.Height = 30;
                dept.Text = "Department: "+resource.studentServices.professonalAdvisors.advisorInformation[i].department;
                dept.Font = new Font("calibri", 10);
                dept.Dock = DockStyle.Top;
                dept.TextAlign = ContentAlignment.MiddleCenter;
                pnl_std_serv_details.Controls.Add(dept);

                //Name
                Label name = new Label();
                name.Height = 30;
                name.Text = "Name: " + resource.studentServices.professonalAdvisors.advisorInformation[i].name;
                name.Font = new Font("calibri", 10);
                name.Dock = DockStyle.Top;
                name.TextAlign = ContentAlignment.MiddleCenter;
                pnl_std_serv_details.Controls.Add(name);

            }

            // Professional Advisors
            Label lbl_std_ser_prof_title = new Label();
            lbl_std_ser_prof_title.Height = 30;
            lbl_std_ser_prof_title.Text = resource.studentServices.professonalAdvisors.title;
            lbl_std_ser_prof_title.Font = new Font("calibri", 14, FontStyle.Bold);
            lbl_std_ser_prof_title.Dock = DockStyle.Top;
            lbl_std_ser_prof_title.TextAlign = ContentAlignment.MiddleCenter;
            pnl_std_serv_details.Controls.Add(lbl_std_ser_prof_title);

            #endregion

            #region Advising

            // Advising FAQ
            Label lb_acad_adv_faq = new Label();
            lb_acad_adv_faq.Height = 30;
            lb_acad_adv_faq.Cursor = Cursors.Hand;
            lb_acad_adv_faq.Text = resource.studentServices.academicAdvisors.faq.title;
            lb_acad_adv_faq.Font = new Font("calibri", 12, FontStyle.Bold);
            lb_acad_adv_faq.Dock = DockStyle.Top;
            lb_acad_adv_faq.TextAlign = ContentAlignment.MiddleCenter;
            lb_acad_adv_faq.Click += (s, p) => makeLink(s, p, resource.studentServices.academicAdvisors.faq.contentHref);
            pnl_std_serv_details.Controls.Add(lb_acad_adv_faq);


            // Advising Desc
            Label lb_acad_adv_desc = new Label();
            lb_acad_adv_desc.Height = 200;
            lb_acad_adv_desc.Text = resource.studentServices.academicAdvisors.description;
            lb_acad_adv_desc.Font = new Font("calibri", 11);
            lb_acad_adv_desc.Dock = DockStyle.Top;
            lb_acad_adv_desc.TextAlign = ContentAlignment.MiddleCenter;
            pnl_std_serv_details.Controls.Add(lb_acad_adv_desc);

            // Advising label
            Label lb_acad_adv = new Label();
            lb_acad_adv.Height = 30;
            lb_acad_adv.Text = resource.studentServices.academicAdvisors.title;
            lb_acad_adv.Font = new Font("calibri", 14, FontStyle.Bold);
            lb_acad_adv.Dock = DockStyle.Top;
            lb_acad_adv.TextAlign = ContentAlignment.MiddleCenter;
            pnl_std_serv_details.Controls.Add(lb_acad_adv);

            #endregion
        }

        private void makeEmail(object sender, EventArgs e)
        {
            Label email = sender as Label;
            System.Diagnostics.Process.Start("mailto:" + email.Text);
        }

        private void makeLink(object sender, EventArgs e, string contentHref)
        {
            System.Diagnostics.Process.Start(contentHref);
        }

        #endregion

        #region Study Abroad
        private void makeStudyAbroad()
        {
            // creating content for Study Abroad
            lbl_stdy_ab_title.Text = resource.studyAbroad.title;
            lbl_stdy_ab_desc.Text = resource.studyAbroad.description;

            lbl_stdy_ab_place_t1.Text = resource.studyAbroad.places[0].nameOfPlace;
            lbl_stdy_ab_place_desc1.Text = resource.studyAbroad.places[0].description;

            lbl_stdy_ab_place_t2.Text = resource.studyAbroad.places[1].nameOfPlace;
            lbl_stdy_ab_place_desc2.Text = resource.studyAbroad.places[1].description;

        }

        #endregion

        private void ResourceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
