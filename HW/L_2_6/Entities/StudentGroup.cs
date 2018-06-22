using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using L_2_6.Exceptions;
using L_2_6.Validators;
using SharedLib.Abstract;

namespace L_2_6.Entities
{
    public class StudentGroup
    {
        private readonly Logger _logger;
        private readonly List<Student> _students;
        private readonly Validator _validator;

        public StudentGroup(List<Student> students, Logger logger) : this(students, logger, new Validator())
        {
        }

        public StudentGroup(List<Student> students, Logger logger, Validator validator)
        {
            _logger = logger;
            _students = students;
            _validator = validator;

            SubscribeLoggerToEvents();
        }

        public string GropName { get; set; }


        public IEnumerable<Student> Students => _students.AsEnumerable();
        public Student this[int index] => _students[index];
        public event EventHandler<StudentCollectinChangedEventArgs> OnCollectionChange;
        public event EventHandler<InvalidStudentInputEventArgs> OnInvalidInput;

        private void SubscribeLoggerToEvents()
        {
            OnCollectionChange += Students_OnCollectionChange;
            OnInvalidInput += Student_OnInvalidInput;
        }


        public void AddStudent(Student student)
        {
            _validator.ValidateNotNull(_students, nameof(_students));

            try
            {
                _validator.ValidateNotNull(student, nameof(student));
                _validator.ValidateNotNullOrEmptyString(student.FirstName, nameof(student.FirstName));
                _validator.ValidateNotNullOrEmptyString(student.LastName, nameof(student.LastName));
            }
            catch (InitializationIssue e)
            {
                OnInvalidInput?.Invoke(this, new InvalidStudentInputEventArgs(e, student));
                throw new InvalidStudentInput("Can't add student. Student is invalid", e, student);
            }

            _students.Add(student);

            OnCollectionChange?.Invoke(this,
                new StudentCollectinChangedEventArgs(CollectionChangeAction.Add, _students, student));
        }

        public void AddStudentsFromGroup(StudentGroup studentGroup)
        {
            _validator.ValidateNotNull(studentGroup, nameof(studentGroup));
            _validator.ValidateNotNull(studentGroup.Students, nameof(studentGroup.Students));

            var newStudents = studentGroup.Students.ToList();

            if (!newStudents.Any()) return;

            var index = 0;

            try
            {
                for (; index < newStudents.Count; index++)
                    AddStudent(newStudents[index]);
            }
            catch (InitializationIssue)
            {
                for (; index > 0; --index)
                    _students.Remove(newStudents[index]);
            }
        }

        private void Student_OnInvalidInput(object sender, InvalidStudentInputEventArgs args)
        {
            if (_logger != null)
            {
                _logger.LogError("Student input was invalid");
                _logger.LogError($" Cause: {args.Exception.Message}", false);
                _logger.LogError($" Item: {args.InvalidStudent}", false);
            }
        }

        private void Students_OnCollectionChange(object sender, StudentCollectinChangedEventArgs args)
        {
            if (_logger != null)
            {
                _logger.LogInfo("Student was added to collection");
                _logger.LogInfo($" Item {args.Student}", false);
            }
        }
    }
}