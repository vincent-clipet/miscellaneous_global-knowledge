using System;
using System.Windows;

namespace School
{
    /// <summary>
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        #region Predefined code

        public StudentForm()
        {
            InitializeComponent();
        }

        #endregion

        // If the user clicks OK to save the Student details, validate the information that the user has provided
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.lastName.Text))
            {
                MessageBox.Show("The student must have a last name", "Last name missing", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(this.dateOfBirth.Text))
            {
                MessageBox.Show("The student must have a birthdate", "Birthdate missing", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime birthdate;
            try
            {
                birthdate = DateTime.Parse(this.dateOfBirth.Text);
            }
            catch (FormatException exc)
            {
                MessageBox.Show("Birthdate is invalid", "Invalid birthdate", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TimeSpan age = DateTime.Now.Subtract(birthdate);
            if ((age.Days / 365.25) < 5)
            {
                MessageBox.Show("The student must be at least 5 years old", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // TODO: Exercise 2: Task 2a: Check that the user has provided a first name
            // TODO: Exercise 2: Task 2b: Check that the user has provided a last name
            // TODO: Exercise 2: Task 3a: Check that the user has entered a valid date for the date of birth
            // TODO: Exercise 2: Task 3b: Verify that the student is at least 5 years old

            // Indicate that the data is valid
            this.DialogResult = true;
        }
    }
}
