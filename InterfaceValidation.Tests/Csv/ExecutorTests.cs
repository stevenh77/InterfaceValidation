using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using InterfaceValidation.Core;
using InterfaceValidation.Validators;

namespace InterfaceValidation.Tests.Csv
{
    [TestClass]
    public class ExecutorTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GivenNullFileSystem_Process_ShouldRaiseNullArgumentException()
        {
            //arrange
            var executor = new InterfaceValidation.Csv.Executor();
            var metadata = new Metadata();
            var validators = new List<IValidator>();

            //act
            executor.Process(null, metadata, validators);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GivenNullMetadata_Process_ShouldRaiseNullArgumentException()
        {
            //arrange
            var executor = new InterfaceValidation.Csv.Executor();
            var fileSystem = new Mocks.FileSystem().Get();
            var validators = new List<IValidator>();

            //act
            executor.Process(fileSystem, null, validators);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GivenNullValidators_Process_ShouldRaiseNullArgumentException()
        {
            //arrange
            var executor = new InterfaceValidation.Csv.Executor();
            var fileSystem = new Mocks.FileSystem().Get();
            var metadata = new Metadata();

            //act
            executor.Process(fileSystem, metadata, null);
        }
    }
}
