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
    public partial class MinorsForm : Form
    {
        UgMinor ugm;
        Course course;
        Dictionary<string, Course> course_dict = new Dictionary<string, Course>();

        // Get restful resources
        REST rest_api_ist = new REST("http://ist.rit.edu/api");

        public MinorsForm()
        {
            InitializeComponent();
        }

        public MinorsForm(UgMinor ugm)
        {
          
            InitializeComponent();
            this.ugm = ugm;
            lbl_title.Text = ugm.title;
            lbl_desc.Text = ugm.description;

            // Courses
            foreach(string course_i in ugm.courses)
            {
                cb_minors_courses.Items.Add(course_i);
            }

            lbl_note.Text = "Note: " + ugm.note;
        }

        private void MinorsForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void cb_minors_courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            string courseID = cb.SelectedItem.ToString();

            if(!course_dict.ContainsKey(courseID))
            {
                string jsonCourseDetails = rest_api_ist.getRestJSON("/course/courseID=" + courseID);
                course = JToken.Parse(jsonCourseDetails).ToObject<Course>();
            }
            else
            {
                course = course_dict[courseID];
            }


            lbl_minor_course_title.Text = course.title;
            lbl_minor_course_title.Visible = true;


            lbl_minor_course_desc.Text = course.description;
            lbl_minor_course_desc.Visible = true;
            //Console.WriteLine(courseID);
        }
    }
}
