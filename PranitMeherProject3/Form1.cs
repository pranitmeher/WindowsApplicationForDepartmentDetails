using Newtonsoft.Json.Linq;
using REST_UTILITY;
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
    public partial class frm_main : Form
    {
        #region GloabalDeclarations
        // Global References
        About about;
        Degrees degrees;
        Minors minors;
        People people;
        Employment employment;
        Research research;
        Resources resources;
        News news;
        Footer footer;
        Courses courses;
        Object contactUs;
        Object footerForAll;

        // Get restful resources
        REST rest_api_ist = new REST("http://ist.rit.edu/api");
        // another one we wont use
        REST rest_api_maps = new REST("http://google.com/api");

        // Active Button
        Button active_but;
        Panel active_panel;
        Button active_but_grad_ug;
        Button active_but_employment;
        Button active_but_people;
        Button active_but_research;

        Dictionary<string, UgMinor> minors_dict = new Dictionary<string, UgMinor>();
        Dictionary<string, Faculty> fac_dict = new Dictionary<string, Faculty>();
        Dictionary<string, Staff> staff_dict = new Dictionary<string, Staff>();
        Dictionary<string, ByInterestArea> aoi_dict = new Dictionary<string, ByInterestArea>();
        Dictionary<string, ByFaculty> fac_int_dict = new Dictionary<string, ByFaculty>();
        Dictionary<string, Object> resources_dict = new Dictionary<string, Object>();

        #endregion

        #region InitializeComponent
        public frm_main()
        {
            InitializeComponent();
        }

        #endregion

        #region FormLoad
        private void Form1_Load(object sender, EventArgs e)
        {
            //// Full Screen
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            //this.WindowState = FormWindowState.Maximized;
            active_panel = pnl_about;
            GenerateContentAbout();
            active_but = btn_about;
            activate_button(active_but);


            // Retrieving data for footer
            string jsonFooter = rest_api_ist.getRestJSON("/footer/");
            footer = JToken.Parse(jsonFooter).ToObject<Footer>();

            footer_wb_copyright.DocumentText = "<body bgcolor = 'black' text = 'white'>"+footer.copyright.html;


        }
        #endregion

        #region LogoMouseOver
        private void pb_rit_logo_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pb_rit_logo, "R.I.T Tiger");
        }
        #endregion

        #region NavigationMenu

        #region ActivateButton
        private void activate_button(Button but)
        {
            if (active_but != null){
                active_but.ForeColor = default(Color);
                active_but.BackColor = default(Color);
                active_but.Enabled = true;
            }

            but.BackColor = Color.Orange;
            but.ForeColor = Color.Black;
            active_but = but;
            active_but.Enabled = false;

        }
        #endregion

        #region ButtonMouseEnter
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button but = sender as Button;
            if(but != active_but)
            {
                but.ForeColor = Color.Orange;
                but.BackColor = default(Color);
            }
            

        }
        #endregion

        #region ButtonMouseLeave
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button but = sender as Button;
            if(but != active_but)
            {
                but.ForeColor = default(Color);
            }

        }
        #endregion

        #region ButtonClick
        private void btn_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("hello");
            Button but = sender as Button;

            // Activate this button (Change its Color)
            if(active_but != but)
            {
                activate_button(but);

                // Call respective functions
                GenerateContent(but.Text);
            }
   
        }
        #endregion

        #endregion

        #region GenerateContentAll
        private void GenerateContent(string but_label)
        {

            // Call function to generate panel for about
            if(but_label == "ABOUT")
            {
                GenerateContentAbout();
                ChangeActivePanel(pnl_about);
            }
            else if (but_label == "DEGREES")
            {
                GenerateContentDegrees();
                ChangeActivePanel(pnl_degrees);
            }
            else if (but_label == "MINORS")
            {
                GenerateContentMinors();
                ChangeActivePanel(pnl_minors);
            }
            else if (but_label == "EMPLOYMENT")
            {
                GenerateContentEmployment();
                ChangeActivePanel(pnl_employment);
            }
            else if (but_label == "PEOPLE")
            {
                GenerateContentPeople();
                ChangeActivePanel(pnl_people);
            }
            else if (but_label == "RESEARCH")
            {
                GenerateContentResearch();
                ChangeActivePanel(pnl_research);
            }
            else if (but_label == "RESOURCES")
            {
                GenerateContentResources();
                ChangeActivePanel(pnl_resources);
            }
            else if (but_label == "RESOURCES")
            {
                GenerateContentResources();
                ChangeActivePanel(pnl_resources);
            }
            else if (but_label == "News")
            {
                GenerateContentNews();
                ChangeActivePanel(pnl_news);
            }
            else if (but_label == "Contact Us")
            {
                GenerateContentContactUs();
                ChangeActivePanel(pnl_contact_us);
            }
            else if (but_label == "Social Presence")
            {
                GenerateContentFooter();
                ChangeActivePanel(pnl_social_presence);
            }
            else if (but_label == "Apply Now")
            {
                GenerateContentFooter();
                ChangeActivePanel(pnl_apply_now);
            }
            else if (but_label == "About This Site")
            {
                GenerateContentFooter();
                ChangeActivePanel(pnl_about_this);
            }
            else if (but_label == "Support IST")
            {
                GenerateContentFooter();
                ChangeActivePanel(pnl_support_ist);
            }
            else if (but_label == "Lab Hours")
            {
                GenerateContentFooter();
                ChangeActivePanel(pnl_lab_hours);
            }
        }
        #region Footer
        private void GenerateContentFooter()
        {
            if (footerForAll == null)
            {
                // Social Presence
                social_tweet.Text = footer.social.tweet;

                pb_facebook.Click += (s, p) => makeLinkPicture(s, p, footer.social.facebook);
                pb_twitter.Click += (s, p) => makeLinkPicture(s, p, footer.social.twitter);

                // Apply Now
                Uri uri_1 = new Uri(footer.quickLinks[0].href);
                wb_apply_now.DocumentText = "<body bgcolor = 'black' text = 'white'>";
                wb_apply_now.Navigate(uri_1);

                // About this
                Uri uri_2 = new Uri(footer.quickLinks[1].href);
                wb_about_this.DocumentText = "<body bgcolor = 'black' text = 'white'>";
                wb_about_this.Navigate(uri_2);

                // Support IST
                Uri uri_3 = new Uri(footer.quickLinks[2].href);
                wb_support.DocumentText = "<body bgcolor = 'black' text = 'white'>";
                wb_support.Navigate(uri_3);

                // Lab Hours
                Uri uri_4 = new Uri(footer.quickLinks[3].href);
                wb_lab_hours.DocumentText = "<body bgcolor = 'black' text = 'white'>";
                wb_lab_hours.Navigate(uri_4);
                footerForAll = 1;

            }
        }



        private void makeLinkPicture(object s, EventArgs p, string url)
        {
            PictureBox pb = s as PictureBox;
            System.Diagnostics.Process.Start(url);

        }

        #endregion

        #region Contact Us
        private void GenerateContentContactUs()
        {
            if(contactUs == null)
            {
                Uri uri = new Uri("http://www.ist.rit.edu/api/contactForm.php");
                contact_us_web.DocumentText = "<body bgcolor = 'black' text = 'white'>";
                contact_us_web.Navigate(uri);
                contactUs = 1;
                
            }

        }
        #endregion

        #region News
        private void GenerateContentNews()
        {
            if (news == null)
            {
                string jsonNews = rest_api_ist.getRestJSON("/news/");
                news = JToken.Parse(jsonNews).ToObject<News>();

                //Add news
                for(int i = 0; i < news.older.Count; i++)
                {
                    rtb_news.AppendText(news.older[i].title.ToUpper() + Environment.NewLine);
                    rtb_news.AppendText(news.older[i].date + Environment.NewLine);
                    rtb_news.AppendText("----------------------------------------------------------------------" + Environment.NewLine);
                    rtb_news.AppendText(news.older[i].description + Environment.NewLine + Environment.NewLine + Environment.NewLine);
                }
            }
        }
        #endregion

        #region GenerateContentResources
        private void GenerateContentResources()
        {
            if (resources == null)
            {
                string jsonResources = rest_api_ist.getRestJSON("/resources/");
                resources = JToken.Parse(jsonResources).ToObject<Resources>();

                lbl_resources_t1.Text = resources.studyAbroad.title;
                resources_dict[resources.studyAbroad.title] = resources.studyAbroad;

                lbl_resources_t2.Text = resources.studentServices.title;
                resources_dict[resources.studentServices.title] = resources.studentServices;

                lbl_resources_t3.Text = resources.tutorsAndLabInformation.title;
                resources_dict[resources.tutorsAndLabInformation.title] = resources.tutorsAndLabInformation;

                lbl_resources_t4.Text = resources.studentAmbassadors.title;
                resources_dict[resources.studentAmbassadors.title] = resources.studentAmbassadors;


                lbl_resources_t5.Text = "Forms";
                resources_dict["Forms"] = resources.forms;

                lbl_resources_t6.Text = resources.coopEnrollment.title;
                resources_dict[resources.coopEnrollment.title] = resources.coopEnrollment;

            }
        }

        #region Resources Mouse Enter,Leave,Click
        private void lbl_resources_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Color.Black;
            lbl.BackColor = Color.Orange;
        }

        private void lbl_resources_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Color.Orange;
            lbl.BackColor = default(Color);
        }

        private void lbl_resources_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            makeResourceWindow(resources, lbl.Text);
        }
        #endregion

        private void makeResourceWindow(Resources res, string whichRes)
        {

            ResourceForm rf = new ResourceForm(res,whichRes);
            rf.Text = whichRes;
            rf.Show();

        }



        #endregion

        #region GenerateContentResearch

        private void GenerateContentResearch()
        {
            // Populating Research Panel
            if (research == null)
            {
                activate_button_research(btn_research_aoi);
                string jsonResearch = rest_api_ist.getRestJSON("/research/");
                research = JToken.Parse(jsonResearch).ToObject<Research>();

                // Title
                lbl_research_title.Text = "RESEARCH";

                // Populating List based on AOI
                for (int i = 0; i < research.byInterestArea.Count; i++)
                {
                    ListViewItem area_name = new ListViewItem();
                    area_name.Text = research.byInterestArea[i].areaName;
                    lv_research_aoi.Items.Add(area_name);
                    if (!aoi_dict.ContainsKey(research.byInterestArea[i].areaName))
                    {
                        aoi_dict.Add(research.byInterestArea[i].areaName, research.byInterestArea[i]);
                    }

                }

                // Populating List based on Faculty
                for (int i = 0; i < research.byFaculty.Count; i++)
                {
                    ListViewItem fac_name = new ListViewItem();
                    fac_name.Text = research.byFaculty[i].facultyName;
                    lv_research_fac.Items.Add(fac_name);
                    if (!fac_int_dict.ContainsKey(research.byFaculty[i].facultyName))
                    {
                        fac_int_dict.Add(research.byFaculty[i].facultyName, research.byFaculty[i]);
                    }

                }
            }

        }

        private void lv_research_aoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView item = sender as ListView;

            if (item.SelectedItems.Count == 0)
                return;

            ListViewItem myItem = item.SelectedItems[0];

            ByInterestArea item_aoi = aoi_dict[myItem.Text];

            // Title
            lbl_research_aoi_title.Text = item_aoi.areaName;

            rtb_research_aoi.Clear();
        

            for (int i = 0; i < item_aoi.citations.Count; i++)
            {
                // Adding Data
                rtb_research_aoi.AppendText("-- " + item_aoi.citations[i] + Environment.NewLine + Environment.NewLine);

            }

            pnl_research_aoi_details.Visible = true;
        }

        private void lv_research_fac_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView item = sender as ListView;

            if (item.SelectedItems.Count == 0)
                return;

            ListViewItem myItem = item.SelectedItems[0];

            ByFaculty item_fac = fac_int_dict[myItem.Text];

            // Title
            lbl_research_fac_title.Text = item_fac.facultyName + " (" + item_fac.username+ ")";

            rtb_research_fac.Clear();


            for (int i = 0; i < item_fac.citations.Count; i++)
            {
                // Adding Data
                rtb_research_fac.AppendText("-- " + item_fac.citations[i] + Environment.NewLine + Environment.NewLine);

            }

            pnl_research_fac_details.Visible = true;
        }

        #region ToggleResearchAoiFac

        private void btn_research_aoi_fac_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            ToggleResearchAoiFac(but);
            activate_button_research(but);
        }


        private void ToggleResearchAoiFac(Button but)
        {
            if (active_but_research != but)
            {
                if (pnl_research_aoi.Visible == true)
                {
                    pnl_research_aoi.Visible = false;
                    pnl_research_fac.Visible = true;

                }
                else
                {
                    pnl_research_fac.Visible = false;
                    pnl_research_aoi.Visible = true;

                }

            }
        }

        #endregion

        #region activate_button_research
        private void activate_button_research(Button but)
        {
            if (active_but_research != null)
            {
                active_but_research.ForeColor = default(Color);
                active_but_research.BackColor = default(Color);
                active_but_research.Enabled = true;
            }

            but.BackColor = Color.Orange;
            but.ForeColor = Color.Black;
            active_but_research = but;
            active_but_research.Enabled = false;
        }

        #endregion

        #endregion

        #region GenerateContentPeople

        private void GenerateContentPeople()
        {
            // Populating Employment Panel
            if (people == null)
            {
                activate_button_people(btn_people_faculty);
                string jsonPeople = rest_api_ist.getRestJSON("/people/");
                people = JToken.Parse(jsonPeople).ToObject<People>();

                // Title
                lbl_people_title.Text = people.title;
                // Faculty

                // Populating Faculty List
                for (int i = 0; i < people.faculty.Count; i++)
                {
                    ListViewItem faculty_name = new ListViewItem();
                    faculty_name.Text = people.faculty[i].name;
                    lv_people_fac.Items.Add(faculty_name);
                    if (!fac_dict.ContainsKey(people.faculty[i].name))
                    {
                        fac_dict.Add(people.faculty[i].name, people.faculty[i]);
                    }

                }

                // Populating Staff List
                for (int i = 0; i < people.staff.Count; i++)
                {
                    ListViewItem staff_name = new ListViewItem();
                    staff_name.Text = people.staff[i].name;
                    lv_people_staff.Items.Add(staff_name);
                    if (!staff_dict.ContainsKey(people.staff[i].name))
                    {
                        staff_dict.Add(people.staff[i].name, people.staff[i]);
                    }

                }
            }

        }

        private void btn_people_fac_staff_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            TogglePeopleFac(but);
            activate_button_people(but);
        }




        #region TogglePeopleFac
        private void TogglePeopleFac(Button but)
        {
            if (active_but_people != but)
            {
                if (pnl_people_fac.Visible == true)
                {
                    pnl_people_fac.Visible = false;
                    pnl_people_staff.Visible = true;

                }
                else
                {
                    pnl_people_staff.Visible = false;
                    pnl_people_fac.Visible = true;

                }

            }
        }

        #endregion

        #region lv_people_fac_SelectedIndexChanged
        private void lv_people_fac_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView item = sender as ListView;

            if (item.SelectedItems.Count == 0)
                return;

            ListViewItem myItem = item.SelectedItems[0];

            Faculty item_fac = fac_dict[myItem.Text];

            

            pnl_people_fac_details.Visible = true;

            // Name
            lbl_people_fac_name.Text = item_fac.name + ", "+ item_fac.title;

            // Image
            pb_people_fac_pic.Load(item_fac.imagePath);

            // Interest Area
            if(item_fac.interestArea == "" || item_fac.interestArea == null)
            {
                lbl_people_fac_intArea.Visible = false;
            }
            else
            {
                lbl_people_fac_intArea.Text = "Interest Areas: "+ item_fac.interestArea;
                lbl_people_fac_intArea.Visible = true;
            }

            // Office
            if (item_fac.office == "" || item_fac.office == null)
            {
                lbl_people_fac_office.Visible = false;
            }
            else
            {
                lbl_people_fac_office.Text = "Office: "+item_fac.office;
                lbl_people_fac_office.Visible = true;
            }

            // Website
            if (item_fac.website == "" || item_fac.website == null)
            {
                lbl_people_fac_website.Visible = false;
            }
            else
            {
                lbl_people_fac_website.Text = item_fac.website;
                lbl_people_fac_website.Visible = true;
                lbl_people_fac_website.Click += makeLink;
            }

            // Phone
            if (item_fac.phone == "" || item_fac.phone == null)
            {
                lbl_people_fac_phone.Visible = false;
            }
            else
            {
                lbl_people_fac_phone.Text = "Phone: " +  item_fac.phone;
                lbl_people_fac_phone.Visible = true;
            }

            // Email
            if (item_fac.email == "" || item_fac.email == null)
            {
                lbl_people_fac_email.Visible = false;
            }
            else
            {
                lbl_people_fac_email.Text = item_fac.email;
                lbl_people_fac_email.Visible = true;
                lbl_people_fac_email.Click += makeEmail;
            }

            // Twitter
            if (item_fac.twitter == "" || item_fac.twitter == null)
            {
                lbl_people_fac_twitter.Visible = false;
            }
            else
            {
                lbl_people_fac_twitter.Text = "https://twitter.com/" + item_fac.twitter;
                lbl_people_fac_twitter.Visible = true;
                lbl_people_fac_twitter.Click += makeLink;
            }
            // Facebook
            if (item_fac.facebook == "" || item_fac.facebook == null)
            {
                lbl_people_fac_facebook.Visible = false;
            }
            else
            {
                lbl_people_fac_facebook.Text = "https://facebook.com/" + item_fac.facebook;
                lbl_people_fac_facebook.Visible = true;
                lbl_people_fac_facebook.Click += makeLink;
            }

        }

        private void makeEmail(object sender, EventArgs e)
        {
             Label email = sender as Label;
            System.Diagnostics.Process.Start("mailto:" + email.Text);
        }

        #endregion

        #region lv_people_staff_SelectedIndexChanged
        private void lv_people_staff_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView item = sender as ListView;

            if (item.SelectedItems.Count == 0)
                return;

            ListViewItem myItem = item.SelectedItems[0];

            Staff item_staff = staff_dict[myItem.Text];



            pnl_people_staff_details.Visible = true;

            // Name
            lbl_people_staff_name.Text = item_staff.name + ", " + item_staff.title;

            // Image
            pb_staff_photo.Load(item_staff.imagePath);

            // Interest Area
            if (item_staff.interestArea == "" || item_staff.interestArea == null)
            {
                lbl_people_staff_intArea.Visible = false;
            }
            else
            {
                lbl_people_staff_intArea.Text = "Interest Areas: " + item_staff.interestArea;
                lbl_people_staff_intArea.Visible = true;
            }

            // Office
            if (item_staff.office == "" || item_staff.office == null)
            {
                lbl_people_staff_Office.Visible = false;
            }
            else
            {
                lbl_people_staff_Office.Text = "Office: " + item_staff.office;
                lbl_people_staff_Office.Visible = true;
            }

            // Website
            if (item_staff.website == "" || item_staff.website == null)
            {
                lbl_people_staff_website.Visible = false;
            }
            else
            {
                lbl_people_staff_website.Text = item_staff.website;
                lbl_people_staff_website.Visible = true;
                lbl_people_staff_website.Click += makeLink;
            }

            // Phone
            if (item_staff.phone == "" || item_staff.phone == null)
            {
                lbl_people_staff_phone.Visible = false;
            }
            else
            {
                lbl_people_staff_phone.Text = "Phone: " + item_staff.phone;
                lbl_people_staff_phone.Visible = true;
            }

            // Email
            if (item_staff.email == "" || item_staff.email == null)
            {
                lbl_people_staff_email.Visible = false;
            }
            else
            {
                lbl_people_staff_email.Text = item_staff.email;
                lbl_people_staff_email.Visible = true;
                lbl_people_staff_email.Click += makeEmail;
            }

            // Twitter
            if (item_staff.twitter == "" || item_staff.twitter == null)
            {
                lbl_people_staff_twitter.Visible = false;
            }
            else
            {
                lbl_people_staff_twitter.Text = "https://twitter.com/" + item_staff.twitter;
                lbl_people_staff_twitter.Visible = true;
                lbl_people_staff_twitter.Click += makeLink;
            }
            // Facebook
            if (item_staff.facebook == "" || item_staff.facebook == null)
            {
                lbl_people_staff_facebook.Visible = false;
            }
            else
            {
                lbl_people_staff_facebook.Text = "https://facebook.com/" + item_staff.facebook;
                lbl_people_staff_facebook.Visible = true;
                lbl_people_staff_facebook.Click += makeLink;
            }
        }

        #endregion

        #region ActivateButtonPeople
        private void activate_button_people(Button but)
        {
            if (active_but_people != null)
            {
                active_but_people.ForeColor = default(Color);
                active_but_people.BackColor = default(Color);
                active_but_people.Enabled = true;
            }

            but.BackColor = Color.Orange;
            but.ForeColor = Color.Black;
            active_but_people = but;
            active_but_people.Enabled = false;
        }
        #endregion



        #endregion

        #region GenerateContentEmployment

        private void GenerateContentEmployment()
        {
            // Populating Employment Panel
            if (employment == null)
            {
                activate_button_employment(btn_emp_page1);

                string jsonEmployment = rest_api_ist.getRestJSON("/employment/");
                employment = JToken.Parse(jsonEmployment).ToObject<Employment>();

                // Title
                lbl_emp_title.Text = employment.introduction.title;

                // For Page 1

                // Employment and Coop
                lbl_emp_t1.Text = employment.introduction.content[0].title;
                lbl_emp_p1_desc1.Text = employment.introduction.content[0].description;
                lbl_emp_t2.Text = employment.introduction.content[1].title;
                lbl_emp_p1_desc2.Text = employment.introduction.content[1].description;

                // Stats
                lbl_emp_p1_11.Text = employment.degreeStatistics.statistics[0].value;
                lbl_emp_p1_12.Text = employment.degreeStatistics.statistics[0].description;
                lbl_emp_p1_21.Text = employment.degreeStatistics.statistics[1].value;
                lbl_emp_p1_22.Text = employment.degreeStatistics.statistics[1].description;
                lbl_emp_p1_31.Text = employment.degreeStatistics.statistics[2].value;
                lbl_emp_p1_32.Text = employment.degreeStatistics.statistics[2].description;
                lbl_emp_p1_41.Text = employment.degreeStatistics.statistics[3].value;
                lbl_emp_p1_42.Text = employment.degreeStatistics.statistics[3].description;

                // For Page 2
                lbl_emp_p2_t1.Text = employment.employers.title;
                lbl_emp_p2_desc1.Text = string.Join(", ", employment.employers.employerNames);
                lbl_emp_p2_t2.Text = employment.careers.title;
                lbl_emp_p2_desc2.Text = string.Join(", ", employment.careers.careerNames);


            }

        }

        private void activate_button_employment(Button but)
        {

            if (active_but_employment != null)
            {
                active_but_employment.ForeColor = default(Color);
                active_but_employment.BackColor = default(Color);
                active_but_employment.Enabled = true;
            }

            but.BackColor = Color.Orange;
            but.ForeColor = Color.Black;
            active_but_employment = but;
            active_but_employment.Enabled = false;
        }

        private void btn_emp_pg1_pg2_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            TogglePg1Pg2(but);
            activate_button_employment(but);
        }

        private void btn_emp_p2_emp_tab_Click(object sender, EventArgs e)
        {

            TableEmpCoop table = new TableEmpCoop(employment, "employer");
            table.Text = "Employment Table";
            table.Show();
        }

        private void btn_emp_p2_coop_tab_Click(object sender, EventArgs e)
        {
            TableEmpCoop table = new TableEmpCoop(employment, "coop");
            table.Text = "Coop Table";
            table.Show();
        }

        #region ToggleEmployment
        private void TogglePg1Pg2(Button but)
        {
            if (active_but_employment != but)
            {
                if (pnl_emp_1.Visible == true)
                {
                    pnl_emp_1.Visible = false;
                    pnl_emp_2.Visible = true;

                }
                else
                {
                    pnl_emp_2.Visible = false;
                    pnl_emp_1.Visible = true;

                }

            }
        }

        #endregion

        #endregion

        #region ChangeActivePanel

        private void ChangeActivePanel(Panel pnl)
        {
            active_panel.Visible = false;
            active_panel = pnl;
            active_panel.Visible = true;
        }

        #endregion

        #region GenerateContentMinors
        private void GenerateContentMinors()
        {
            if (minors == null)
            {
                string jsonMinors = rest_api_ist.getRestJSON("/minors/");
                minors = JToken.Parse(jsonMinors).ToObject<Minors>();

                int count = 0;

                // Traversing Cells
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Control lbl =   tbl_minors.GetControlFromPosition(i, j);
                        lbl.Text = minors.UgMinors[count].title;

                        minors_dict.Add(minors.UgMinors[count].title, minors.UgMinors[count]);
                        count++;
                    }
                }


            }
        }


        private void lbl_minors_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Color.Black;
            lbl.BackColor = Color.Orange;
        }

        private void lbl_minors_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Color.Orange;
            lbl.BackColor = default(Color);
        }

        private void lbl_minors_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            UgMinor ugm = minors_dict[lbl.Text];

            makeMinorWindow(ugm);
        }

        private void makeMinorWindow(UgMinor ugm)
        {
            MinorsForm mf = new MinorsForm(ugm);
            mf.Text = "Undergraduate Minor";
            mf.Show();

        }
        #endregion

        #region GenerateContentAbout
        private void GenerateContentAbout()
        {
            if (about == null)
            {
                string jsonAbout = rest_api_ist.getRestJSON("/about/");
                about = JToken.Parse(jsonAbout).ToObject<About>();

                lbl_about_title.Text = about.title;
                lbl_about_description.Text = about.description;
                lbl_about_quote.Text = about.quote;
                lbl_about_author.Text = "-" + about.quoteAuthor;
            }

        }

        #endregion

        #region GenerateContentDegrees
        private void GenerateContentDegrees()
        {
            if(degrees == null)
            {
                // Active button for Grad/ Undergrad
                //active_but_grad_ug = btn_deg_undergrad;
                activate_button_grad_undergrad(btn_deg_undergrad);

                string jsonDegrees = rest_api_ist.getRestJSON("/degrees/");
                degrees = JToken.Parse(jsonDegrees).ToObject<Degrees>();

                #region undergraduateDegrees

                // Generating content for Undergraduate Degrees
                Panel[] panels_ug = { pnl_deg_ug_1, pnl_deg_ug_2, pnl_deg_ug_3 };
                for (int i = 0; i < degrees.undergraduate.Count; i++)
                {

                    string[] panels_controls_list = { "http://" + degrees.undergraduate[i].degreeName + ".rit.edu", string.Join(", ", degrees.undergraduate[i].concentrations), degrees.undergraduate[i].description, degrees.undergraduate[i].title };
                    for (int j = 0; j < panels_ug[i].Controls.Count; j++)
                    {
                        
                        Control childControl = panels_ug[i].Controls[j];
                        childControl.Text = panels_controls_list[j];

                        if (j == 0)
                        {
                            childControl.Cursor = Cursors.Hand;
                            childControl.Click += makeLink;
                        }
                    }
                    
                }
                #endregion

                #region GraduateDegrees

                // Generating content for Graduate Degrees
                Panel[] panels_grad = { pnl_deg_grad_1, pnl_deg_grad_2, pnl_deg_grad_3 };

                for (int i = 0; i < degrees.graduate.Count -1; i++)
                {

                    string[] panels_controls_list = { "http://" + degrees.graduate[i].degreeName + ".rit.edu", string.Join(", ", degrees.graduate[i].concentrations), degrees.graduate[i].description, degrees.graduate[i].title };

                    for (int j = 0; j < panels_grad[i].Controls.Count; j++)
                    {

                        Control childControl = panels_grad[i].Controls[j];
                        childControl.Text = panels_controls_list[j];

                        if(j == 0)
                        {
                            childControl.Cursor = Cursors.Hand;
                            childControl.Click += makeLink;
                        }

                    }

                }

               

                // Adding Certificates to Grad Degrees
                cert_title.Text = degrees.graduate[degrees.graduate.Count -1].degreeName;

                cert1.Text = degrees.graduate[degrees.graduate.Count -1].availableCertificates[0];
                cert2.Text = degrees.graduate[degrees.graduate.Count -1].availableCertificates[1];


                #endregion
            }


        }

        private void makeLink(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            System.Diagnostics.Process.Start(lbl.Text);
        }

        private void cert1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.rit.edu/programs/web-development-adv-cert");
        }

        private void cert2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.rit.edu/programs/networking-planning-and-design-adv-cert");
        }


        #region GradUndergradToggle

        private void ToggleGradUndergrad(Button but)
        {
            if (active_but_grad_ug != but)
            {
                if(pnl_deg_grad.Visible == true)
                {
                    pnl_deg_grad.Visible = false;
                    pnl_deg_ug.Visible = true;

                }
                else
                {
                    pnl_deg_ug.Visible = false;
                    pnl_deg_grad.Visible = true;

                }
               
            }
        }

        private void btn_deg_undergrad_grad_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            ToggleGradUndergrad(but);
            activate_button_grad_undergrad(but);
        }

        private void activate_button_grad_undergrad(Button but)
        {
            
            if (active_but_grad_ug != null)
            {
                active_but_grad_ug.ForeColor = default(Color);
                active_but_grad_ug.BackColor = default(Color);
                active_but_grad_ug.Enabled = true;
            }

            but.BackColor = Color.Orange;
            but.ForeColor = Color.Black;
            active_but_grad_ug = but;
            active_but_grad_ug.Enabled = false;
        }







        #endregion

        #endregion

        #endregion


    }
}
