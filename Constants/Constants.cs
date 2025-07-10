﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Constants
{
    public static class AppConstants
    {
        // Person
        public const int MinNameLength = 1;
        public const int MaxNameLength = 100;
        public const int MinAddressLength = 1;
        public const int MaxAddressLength = 300;
        public const double MinHeight = 50.0;
        public const double MaxHeight = 300.0;
        public const double MinWeight = 5.0;
        public const double MaxWeight = 1000.0;
        public const int MinBirthYear = 1900;

        // Student 
        public const int StudentIdLength = 8;
        public const int MinUniversityLength = 1;
        public const int MaxUniversityLength = 200;
        public const int MinAcademicYear = 1900;

        // GPA
        public const double MinGpa = 0.0;
        public const double MaxGpa = 10.0;

        public const string DataFileName = "../../../StudentList.txt";
    }
}
