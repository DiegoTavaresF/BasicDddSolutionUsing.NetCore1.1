using Domain.Entities;
using Domain.Entities.ExamplesEntity;
using Xunit;
using XUnitTestDomain.Base;

namespace XUnitTestDomain.Entities
{
    public class ExampleEntityTest
    {
        private StringUtils stringUtils = new StringUtils();

        [Fact]
        public void SetNameInvalidMaxLength()
        {
            var exampleEntity = new ExampleEntity();
            exampleEntity.Errors.Clear();
            exampleEntity.SetName(stringUtils.RandomString(PropertyLength.ExampleEntity_Name_MaxLength + 1));

            Assert.Equal(false, exampleEntity.IsValid());
        }

        [Fact]
        public void SetNameInvalidMinLength()
        {
            var exampleEntity = new ExampleEntity();
            exampleEntity.Errors.Clear();
            exampleEntity.SetName(stringUtils.RandomString(PropertyLength.ExampleEntity_Name_MinLength - 1));

            Assert.Equal(false, exampleEntity.IsValid());
        }

        [Fact]
        public void SetNameValidLength()
        {
            var exampleEntity = new ExampleEntity();
            exampleEntity.SetName("new name");
            Assert.Equal(true, exampleEntity.IsValid());
        }
    }
}