using InterfaceValidation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterfaceValidation.Tests.Validators
{
    [TestClass]
    public class RequiredFileValidatorTests
    {
        [TestMethod]
        public void Validate()
        {
            //arrange
            var validator = new RequiredFileValidator();
            var fileSystem = new Mocks.FileSystem().Get();
            var metadata = new Mocks.MetadataService().Get();

            //act
            var errors = validator.Validate(fileSystem, metadata);

            //assert
            var expected = 2;
            Assert.AreEqual(expected, errors.Count);
        }
    }
}
