using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Satistools.DataReader.Entities.Items;

namespace Satistools.DataReader.Test;

public class EntityResolverTest
{
    /// <summary>
    /// Tests if we can resolve particular data entities in the assembly.
    /// </summary>
    [Test]
    public void Test_ResolveEntities()
    {
        Dictionary<Type, string> entities = EntityResolver.Resolve();
        entities.Should().HaveCountGreaterThan(0);
        KeyValuePair<Type, string> entity = entities.Single(v => v.Value == "Class'/Script/FactoryGame.FGItemDescriptor'");

        entity.Key.Should().Be<ItemDescriptor>();
        entity.Value.Should().Be("Class'/Script/FactoryGame.FGItemDescriptor'");
    }
}