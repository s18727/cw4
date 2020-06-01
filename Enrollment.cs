using System;

namespace zad4
{
    public class Enrollment
    {
        private int idEnrollment;

        public int GetIdEnrollment()
        {
            return idEnrollment;
        }

        public void SetIdEnrollment(int value)
        {
            idEnrollment = value;
        }

        private int semester;

        public int GetSemester()
        {
            return semester;
        }

        public void SetSemester(int value)
        {
            semester = value;
        }

        private int idStudy;

        public int GetIdStudy()
        {
            return idStudy;
        }

        public void SetIdStudy(int value)
        {
            idStudy = value;
        }

        private DateTime startDate;

        public DateTime GetStartDate()
        {
            return startDate;
        }

        public void SetStartDate(DateTime value)
        {
            startDate = value;
        }

        public override string ToString()
        {
            return "IdEnrollment: " + GetIdEnrollment() + 
                ", Semester: " + GetSemester() + 
                ", IdStudy: " + GetIdStudy() + 
                ", Start Date: " + GetStartDate().ToString("MM/dd/yyyy");
        }
    }
}