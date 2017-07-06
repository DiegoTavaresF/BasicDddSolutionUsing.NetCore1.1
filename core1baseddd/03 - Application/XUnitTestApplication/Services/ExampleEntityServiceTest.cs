using Application.Services.ExamplesEntity;
using Domain.Entities.ExamplesEntity;
using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using XUnitTestApplication.Base;

namespace XUnitTestApplication.Services
{
    public class ExampleEntityServiceTest
    {
        [Fact]
        public void GetDropdown()
        {
            var examples = new List<ExampleEntity>
            {
                new ExampleEntity ("Example 1"),
                new ExampleEntity ("Example 2"),
                new ExampleEntity ("Example 3"),
            };

            var mockSet = ContextMock.CreateMockForDbSet<ExampleEntity>()
                                                            .SetupForQueryOn(examples);

            var mockContext = ContextMock.CreateMockForDbContext(mockSet);

            var service = new ExampleEntityService(mockContext.Object, null);

            var result = service.GetDropdown();
        }
    }
}