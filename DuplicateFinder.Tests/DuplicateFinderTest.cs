using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Assert.IsTrue(result.Count == 4);
        }
    }
}
