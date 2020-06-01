namespace zad4
{
    public class Student
    {
        private string indexNumber;

        public string GetIndexNumber()
        {
            return indexNumber;
        }

        public void SetIndexNumber(string value)
        {
            indexNumber = value;
        }

        private string firstName;

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetFirstName(string value)
        {
            firstName = value;
        }

        private string lastName;

        public string GetLastName()
        {
            return lastName;
        }

        public void SetLastName(string value)
        {
            lastName = value;
        }
    }
}