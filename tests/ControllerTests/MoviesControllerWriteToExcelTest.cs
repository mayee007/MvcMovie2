using Xunit; 
using MvcMovie2.Controllers; 
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models; 
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Moq; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Linq; 
using System; 
using System.Data;  
using NPOI.HSSF.UserModel;  
using Newtonsoft.Json;  
using System.IO;
using Npoi.Mapper; 
using Npoi.Mapper.Attributes;
using NPOI.SS.UserModel;

namespace MvcMovie.tests.ControllerTests 
{
    public class MoviesControllerWriteToExcelTest
    {
        string filePath; 
        Movie movie1;
        Movie movie2;  
        List<Movie> movieList; 
        
        public MoviesControllerWriteToExcelTest() 
        {
            filePath = "C:\\Users\\mayee\\source\\repos\\MvcMovie2\\generatedFromTest.xls"; 
            movie1 = new Movie { Id = 1, Genre = "Classic", Title = "Redemption", Price = 10.05M, ReleaseDate=new DateTime(2001, 1, 18) };            
            movie2 = new Movie { Id = 2, Genre = "Classic", Title = "Shark", Price = 15.05M, ReleaseDate=new DateTime(2005, 5, 23) };            
            movieList = new List<Movie>();
        }

        [Fact]
        public void exportToExcel() 
        {    
            var workbook = new HSSFWorkbook();  
            var sheet = workbook.CreateSheet("CreatedFromTest");
        
            var headerRow = sheet.CreateRow(0);  
            headerRow.CreateCell(0).SetCellValue("Id"); 
            headerRow.CreateCell(1).SetCellValue("Title");
            headerRow.CreateCell(2).SetCellValue("ReleaseDate");           
            headerRow.CreateCell(3).SetCellValue("Genre");
            headerRow.CreateCell(4).SetCellValue("Price");

            var row1 = sheet.CreateRow(1);  
            row1.CreateCell(0).SetCellValue(movie1.Id); 
            row1.CreateCell(1).SetCellValue(movie1.Title);
            row1.CreateCell(2).SetCellValue(movie1.ReleaseDate);           
            row1.CreateCell(3).SetCellValue(movie1.Genre);
            row1.CreateCell(4).SetCellValue(10.05D); 
            
            row1 = sheet.CreateRow(2);  
            row1.CreateCell(0).SetCellValue(movie2.Id); 
            row1.CreateCell(1).SetCellValue(movie2.Title);
            row1.CreateCell(2).SetCellValue(movie2.ReleaseDate);           
            row1.CreateCell(3).SetCellValue(movie2.Genre);
            row1.CreateCell(4).SetCellValue(15.05D);

            // Declare one MemoryStream variable for write file in stream  
            var stream = new MemoryStream();  
            workbook.Write(stream); 
        
            //Write to file using file stream  
            FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);  
            stream.WriteTo(file);  
            file.Close();  
            stream.Close();            
        }

        [Fact]
        public void addMovies()
        {    
            IWorkbook workbook;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = WorkbookFactory.Create(file);
            }

            var importer = new Mapper(workbook);
            var items = importer.Take<Movie>(0); // read first sheet
            foreach (var item in items)
            {
                movieList.Add(item.Value);             
            }       

            Movie movie = movieList.ElementAt(0); 
            Assert.Equal(1, movie.Id); 
            Assert.Equal("Classic", movie.Genre);
            Assert.Equal("Redemption", movie.Title); 

            movie = movieList.ElementAt(1); 
            Assert.Equal(2, movie.Id); 
            Assert.Equal("Classic", movie.Genre);
            Assert.Equal("Shark", movie.Title);  

            // call addcontroller
             
        }
        
    }
}