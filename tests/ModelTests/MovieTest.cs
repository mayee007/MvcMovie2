using Xunit; 
using System; 
using MvcMovie2.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Reflection;

namespace MvcMovie2.tests.ModelTests 
{
    public class MovieTest
    {
        Movie movie;
        List<String> allMovieAttributes; 

        public MovieTest()
        {
            movie = new Movie(); 
            movie.Id = 10; 
            movie.Genre = "Classic"; 
            //movie.Price = 15.60M; 
            movie.Title = "Deep Blue Sea"; 
            movie.ReleaseDate = DateTime.Parse("1989-2-12");

            allMovieAttributes = new List<String>(); 
        }

        [Fact]
        public void Id() 
        {
            Assert.Equal(10, movie.Id); 
            Assert.Equal("Classic", movie.Genre);
            Assert.Equal("Deep Blue Sea", movie.Title);
            Assert.Equal(DateTime.Parse("1989-2-12"), movie.ReleaseDate);
        }

        [Fact]
        public void fieldRequiredTest()
        {
            // required field "true"
            Assert.True(isItRequiredField("Title"));
            Assert.True(isItRequiredField("Genre"));

            //required field "false"
            Assert.False(isItRequiredField("Id"));
            Assert.True(isItRequiredField("Price"));

            List<String> requiredFields = new List<String>();
            requiredFields = getAllRequiredFields();
            foreach(var field in requiredFields) 
            {
                movie.GetType().GetProperty(field).GetValue(movie, null).ToString();
            }

            Type movieType = typeof(Movie);
            PropertyInfo[] propertyInfo = movieType.GetProperties();
            foreach (PropertyInfo pInfo in propertyInfo)
            {
                Console.WriteLine(pInfo.Name);
                FieldInfo info = movieType.GetField(pInfo.Name);
                Console.WriteLine(info.GetValue(movie)); 
            }

            //FieldInfo[] fields = movieType.GetFields(BindingFlags.Public
            //| BindingFlags.Instance);

            /* FieldInfo[] fields = movieType.GetFields(BindingFlags.Public);
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine("   {0}:\t'{1}'",
                    fields[i].Name, fields[i].GetValue(movie));
            } */ 

            //String genre = movie.GetPropertyValue("Genre"); 
        }

        public List<String> getAllRequiredFields()
        { 
            var fields = movie.GetType().GetProperties();
            List<String> ll = new List<String>(); 
            foreach (var field in fields)
            {
                if (isItRequiredField(field.Name))
                {
                    ll.Add(field.Name);
                }
            }
            return ll; 
        } // end of function getAllRequiredFields

        public bool isItRequiredField(String fieldName)
        {
            var t = typeof(Movie);
            var field = t.GetProperty(fieldName);
            return Attribute.IsDefined(field, typeof(RequiredAttribute));
        }
    }
}