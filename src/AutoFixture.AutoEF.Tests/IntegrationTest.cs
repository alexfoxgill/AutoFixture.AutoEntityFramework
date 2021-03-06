﻿using AutoFixture.AutoEF.Tests.MockEntities;
using FluentAssertions;
using AutoFixture;
using AutoFixture.Xunit2;
using System;
using Xunit.Extensions;
using Theory = Xunit.TheoryAttribute;

namespace AutoFixture.AutoEF.Tests
{
    public class AutoEFDataAttribute : AutoDataAttribute
    {
        public AutoEFDataAttribute(Type dbContextType)
            : base(() => new Fixture()
                .Customize(new EntityCustomization(new DbContextEntityTypesProvider(dbContextType))))
        { }
    }

    public class IntegrationTests
    {
        [Theory, AutoEFData(typeof(MockDbContext))]
        public void FixtureCanCreateEFEntity(Foo foo)
        {
            foo.Should().NotBeNull();
        }

        [Theory, AutoEFData(typeof (MockDbContext))]
        public void GeneratedPropertyIsNotNull(Foo foo)
        {
            foo.Bar.Should().NotBeNull();
        }
        
        [Theory, AutoEFData(typeof (MockDbContext))]
        public void GeneratedCollectionIsNotEmpty(Bar bar)
        {
            bar.Quxes.Should().NotBeEmpty();
        }

        [Theory, AutoEFData(typeof (MockDbContext))]
        public void GeneratedCollectionCanBeCleared(Bar bar)
        {
            bar.Quxes.Clear();
            bar.Quxes.Should().HaveCount(0);
        }

        [Theory, AutoEFData(typeof (MockDbContext))]
        public void IdShouldMatchNavigationPropertyId(Foo foo)
        {
            foo.BarId.Should().Be(foo.Bar.Id);
        }

        [Theory, AutoEFData(typeof (MockDbContext))]
        public void ParentShouldBeSameObject(Foo foo)
        {
            foo.Bar.Foo.Should().BeSameAs(foo);
        }

        [Theory, AutoEFData(typeof(MockDbContext))]
        public void ParentIdShouldBeSame(Foo foo)
        {
            foo.Bar.FooId.Should().Be(foo.Id);
        }

        [Theory, AutoEFData(typeof(MockDbContext))]
        public void ParentShouldBeSameForCollections(Bar bar)
        {
            foreach (var qux in bar.Quxes)
            {
                (qux.Bar == bar).Should().BeTrue();
            }
        }

        [Theory, AutoEFData(typeof(MockDbContext))]
        public void RepeatedAccessYieldsSameObject(Foo foo)
        {
            var bar1 = foo.Bar;
            var bar2 = foo.Bar;

            bar1.Should().BeSameAs(bar2);
        }

        [Theory, AutoEFData(typeof (MockDbContext))]
        public void UnfrozenTypeYieldsDifferentObject(Bar bar, Foo foo)
        {
            foo.Bar.Should().NotBeSameAs(bar);
        }

        [Theory, AutoEFData(typeof(MockDbContext))]
        public void FrozenTypeYieldsSameObject([Frozen] Bar bar, Foo foo)
        {
            foo.Bar.Should().BeSameAs(bar);
        }

        [Theory, AutoEFData(typeof(MockDbContext))]
        public void IdShouldMatchNavigationPropertyIdWhenTableNameId(Far far)
        {
            far.BooId.Should().Be(far.Boo.BooId);
        }

        [Theory, AutoEFData(typeof(MockDbContext))]
        public void ParentIdShouldBeSameWhenTableNameId(Far far)
        {
            far.Boo.FarId.Should().Be(far.FarId);
        }

        [Theory, AutoEFData(typeof(MockDbContext))]
        public void ParentIdShouldBeSameForCollectionsWhenTableNameId(Boo boo)
        {
            foreach (var qix in boo.Qixes)
            {
                qix.BooId.Should().Be(boo.BooId);
            }
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void FixtureCanCreateEFEntityForIDbSet(Foo foo)
        {
            foo.Should().NotBeNull();
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void GeneratedPropertyIsNotNullForIDbSet(Foo foo)
        {
            foo.Bar.Should().NotBeNull();
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void GeneratedCollectionIsNotEmptyForIDbSet(Bar bar)
        {
            bar.Quxes.Should().NotBeEmpty();
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void GeneratedCollectionCanBeClearedForIDbSet(Bar bar)
        {
            bar.Quxes.Clear();
            bar.Quxes.Should().HaveCount(0);
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void IdShouldMatchNavigationPropertyIdForIDbSet(Foo foo)
        {
            foo.BarId.Should().Be(foo.Bar.Id);
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void ParentShouldBeSameObjectForIDbSet(Foo foo)
        {
            foo.Bar.Foo.Should().BeSameAs(foo);
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void ParentIdShouldBeSameForIDbSet(Foo foo)
        {
            foo.Bar.FooId.Should().Be(foo.Id);
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void ParentShouldBeSameForCollectionsForIDbSet(Bar bar)
        {
            foreach (var qux in bar.Quxes)
            {
                (qux.Bar == bar).Should().BeTrue();
            }
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void RepeatedAccessYieldsSameObjectForIDbSet(Foo foo)
        {
            var bar1 = foo.Bar;
            var bar2 = foo.Bar;

            bar1.Should().BeSameAs(bar2);
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void UnfrozenTypeYieldsDifferentObjectForIDbSet(Bar bar, Foo foo)
        {
            foo.Bar.Should().NotBeSameAs(bar);
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void FrozenTypeYieldsSameObjectForIDbSet([Frozen] Bar bar, Foo foo)
        {
            foo.Bar.Should().BeSameAs(bar);
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void IdShouldMatchNavigationPropertyIdWhenTableNameIdForIDbSet(Far far)
        {
            far.BooId.Should().Be(far.Boo.BooId);
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void ParentIdShouldBeSameWhenTableNameIdForIDbSet(Far far)
        {
            far.Boo.FarId.Should().Be(far.FarId);
        }

        [Theory, AutoEFData(typeof(MockDbContextIDbSet))]
        public void ParentIdShouldBeSameForCollectionsWhenTableNameIdForIDbSet(Boo boo)
        {
            foreach (var qix in boo.Qixes)
            {
                qix.BooId.Should().Be(boo.BooId);
            }
        }
    }
}
