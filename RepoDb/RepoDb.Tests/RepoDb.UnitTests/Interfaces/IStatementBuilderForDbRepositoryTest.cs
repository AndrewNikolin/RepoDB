﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepoDb.Attributes;
using RepoDb.Interfaces;
using RepoDb.UnitTests.CustomObjects;
using System.Collections.Generic;

namespace RepoDb.UnitTests.Interfaces
{
    [TestClass]
    public class IStatementBuilderForDbRepositoryTest
    {
        public class StatementBuilderForDbRepositoryDataEntity
        {
            [Primary, Identity]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class StatementBuilderForDbRepositoryDataEntityT1
        {
            [Primary, Identity]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class StatementBuilderForDbRepositoryDataEntityT2
        {
            [Primary, Identity]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class StatementBuilderForDbRepositoryDataEntityT3
        {
            [Primary, Identity]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class StatementBuilderForDbRepositoryDataEntityT4
        {
            [Primary, Identity]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class StatementBuilderForDbRepositoryDataEntityT5
        {
            [Primary, Identity]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class StatementBuilderForDbRepositoryDataEntityT6
        {
            [Primary, Identity]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class StatementBuilderForDbRepositoryDataEntityT7
        {
            [Primary, Identity]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        // CreateBatchQuery

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForBatchQuery()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.BatchQuery<StatementBuilderForDbRepositoryDataEntity>(0, 10, null, null);

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateBatchQuery<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<IEnumerable<OrderField>>(),
                    It.IsAny<string>()), Times.Once);
        }

        // CreateCount

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForCount()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.Count<StatementBuilderForDbRepositoryDataEntity>();

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateCount<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<string>()), Times.Once);
        }

        // CreateDelete

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForDelete()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.Delete<StatementBuilderForDbRepositoryDataEntity>(e => e.Id == 1);

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateDelete<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>()), Times.Once);
        }

        // CreateDeleteAll

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForDeleteAll()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.DeleteAll<StatementBuilderForDbRepositoryDataEntity>();

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateDeleteAll<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>()), Times.Once);
        }

        // CreateInlineInsert

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForInlineInsert()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.InlineInsert<StatementBuilderForDbRepositoryDataEntity>(new { Id = 1, Name = "Name" });

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateInlineInsert<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<DbField>(),
                    It.IsAny<IEnumerable<Field>>()), Times.Once);
        }

        // CreateInlineMerge

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForInlineMerge()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.InlineMerge<StatementBuilderForDbRepositoryDataEntity>(new { Name = "Name" }, new Field(nameof(StatementBuilderForDbRepositoryDataEntity.Id)));

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateInlineMerge<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<DbField>(),
                    It.IsAny<IEnumerable<Field>>(),
                    It.IsAny<IEnumerable<Field>>()), Times.Once);
        }

        // CreateInlineUpdate

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForInlineUpdate()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.InlineUpdate<StatementBuilderForDbRepositoryDataEntity>(new { Name = "Name" }, e => e.Id == 1);

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateInlineUpdate<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<IEnumerable<Field>>(),
                    It.IsAny<QueryGroup>()), Times.Once);
        }

        // CreateInsert

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForInsert()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.Insert<StatementBuilderForDbRepositoryDataEntity>(new StatementBuilderForDbRepositoryDataEntity { Name = "Name" });

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateInsert<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<DbField>()), Times.Once);
        }

        // CreateMerge

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForMerge()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.Merge<StatementBuilderForDbRepositoryDataEntity>(new StatementBuilderForDbRepositoryDataEntity { Name = "Name" }, new Field(nameof(StatementBuilderForDbRepositoryDataEntity.Id)));

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateMerge<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<DbField>(),
                    It.IsAny<IEnumerable<Field>>()), Times.Once);
        }

        // CreateQuery

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForQuery()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.Query<StatementBuilderForDbRepositoryDataEntity>(e => e.Id == 1);

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateQuery<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<IEnumerable<OrderField>>(),
                    It.IsAny<int>(),
                    It.IsAny<string>()), Times.Once);
        }

        // QueryMultple

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForQueryMultiple()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.QueryMultiple<StatementBuilderForDbRepositoryDataEntityT1,
                StatementBuilderForDbRepositoryDataEntityT2,
                StatementBuilderForDbRepositoryDataEntityT3,
                StatementBuilderForDbRepositoryDataEntityT4,
                StatementBuilderForDbRepositoryDataEntityT5,
                StatementBuilderForDbRepositoryDataEntityT6,
                StatementBuilderForDbRepositoryDataEntityT7>(e => e.Id == 1,
                e => e.Id == 1,
                e => e.Id == 1,
                e => e.Id == 1,
                e => e.Id == 1,
                e => e.Id == 1,
                e => e.Id == 1);

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateQuery<StatementBuilderForDbRepositoryDataEntityT1>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<IEnumerable<OrderField>>(),
                    It.IsAny<int>(),
                    It.IsAny<string>()), Times.Exactly(1));
            statementBuilder.Verify(builder =>
                builder.CreateQuery<StatementBuilderForDbRepositoryDataEntityT2>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<IEnumerable<OrderField>>(),
                    It.IsAny<int>(),
                    It.IsAny<string>()), Times.Exactly(1));
            statementBuilder.Verify(builder =>
                builder.CreateQuery<StatementBuilderForDbRepositoryDataEntityT3>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<IEnumerable<OrderField>>(),
                    It.IsAny<int>(),
                    It.IsAny<string>()), Times.Exactly(1));
            statementBuilder.Verify(builder =>
                builder.CreateQuery<StatementBuilderForDbRepositoryDataEntityT4>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<IEnumerable<OrderField>>(),
                    It.IsAny<int>(),
                    It.IsAny<string>()), Times.Exactly(1));
            statementBuilder.Verify(builder =>
                builder.CreateQuery<StatementBuilderForDbRepositoryDataEntityT5>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<IEnumerable<OrderField>>(),
                    It.IsAny<int>(),
                    It.IsAny<string>()), Times.Exactly(1));
            statementBuilder.Verify(builder =>
                builder.CreateQuery<StatementBuilderForDbRepositoryDataEntityT6>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<IEnumerable<OrderField>>(),
                    It.IsAny<int>(),
                    It.IsAny<string>()), Times.Exactly(1));
            statementBuilder.Verify(builder =>
                builder.CreateQuery<StatementBuilderForDbRepositoryDataEntityT7>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<IEnumerable<OrderField>>(),
                    It.IsAny<int>(),
                    It.IsAny<string>()), Times.Exactly(1));
        }

        // CreateTruncate

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForTruncate()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.Truncate<StatementBuilderForDbRepositoryDataEntity>();

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateTruncate<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>()), Times.Once);
        }

        // CreateUpdate

        [TestMethod]
        public void TestDbRepositoryStatementBuilderForUpdate()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new DbRepository<CustomDbConnection>("ConnectionString", statementBuilder.Object);

            // Act
            repository.Update<StatementBuilderForDbRepositoryDataEntity>(new StatementBuilderForDbRepositoryDataEntity { Name = "Update" }, e => e.Id == 1);

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateUpdate<StatementBuilderForDbRepositoryDataEntity>(
                    It.IsAny<QueryBuilder>(),
                    It.IsAny<QueryGroup>()), Times.Once);
        }
    }
}
