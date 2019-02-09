using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ImageDupliFinder.Tests
{
    [TestClass]
    public class ImagesAnalyzerTest
    {
        [TestMethod]
        public void TestFindingDuplicateFiles()
        {
            var ia = new DuplicateFinder();

            ia.FindFiles(@"..\..\..\Images", "*.jpg");
            var result = ia.GetDuplicatesList();
            var grouped = ia.GetDuplicates();

            string moved_files = ia.MoveDuplicates(@"..\..\..\Images\deleted", @"Images\img2");

            System.Console.WriteLine(moved_files);

            Assert.IsTrue(result.Count == 4);
        }
    }
}
