using System;
using Catnap.Find;
using Catnap.Find.Conditions;
using Catnap.Maps;
using Catnap.UnitTests.Models;
using Machine.Specifications;
using ShouldIt.Clr.Fluent;

namespace Catnap.UnitTests
{
    //public class when_creating_an_equal_condition
    //{
    //    static Equal target;

    //    Because of = () => target = new Equal("Foo", 100);

    //    It should_render_correct_string = () => target.ToString().Should().Equal("(Foo = @Foo)");

    //    It should_contain_expected_parameters = () =>
    //    {
    //        target.Parameters.Should().Count.Exactly(1);
    //        target.Parameters.Should().Contain.One(x => x.Name == "@Foo" && (int)x.Value == 100);
    //    };
    //}

    //public class when_creating_a_not_equal_condition
    //{
    //    static NotEqual target;

    //    Because of = () => target = new NotEqual("Foo", 100);

    //    It should_render_correct_string = () => target.ToString().Should().Equal("(Foo != @Foo)");

    //    It should_contain_expected_parameters = () =>
    //    {
    //        target.Parameters.Should().Count.Exactly(1);
    //        target.Parameters.Should().Contain.One(x => x.Name == "@Foo" && (int)x.Value == 100);
    //    };
    //}

    public class when_creating_an_complex_condition
    {
        static Criteria target;

        private Because of = () =>
        {
            DomainMap.Configure(new EntityMap<Person>().Property(x => x.FirstName));
            target = new Criteria
            (
                Condition.Less("Bar", 1000),
                Condition.GreaterOrEqual("Bar", 300),
                Condition.Or
                (
                    Condition.NotEqual<Person>(x => x.FirstName, "Tim"),
                    Condition.And
                    (
                        Condition.Equal("Foo", 25),
                        Condition.Equal("Baz", 500)
                    )
                )
            );
        };

        It should_render_correct_string = () => target.Build().ToString().Should()
            .Equal("((Bar < @0) and (Bar >= @1) and ((FirstName != @2) or ((Foo = @3) and (Baz = @4))))");

        It should_contain_expected_parameters = () =>
        {
            target.Parameters.Should().Count.Exactly(5);
            target.Parameters.Should().Contain.One(x => x.Name == "@0" && x.Value.Equals(1000));
            target.Parameters.Should().Contain.One(x => x.Name == "@1" && x.Value.Equals(300));
            target.Parameters.Should().Contain.One(x => x.Name == "@2" && x.Value.Equals("Tim"));
            target.Parameters.Should().Contain.One(x => x.Name == "@3" && x.Value.Equals(25));
            target.Parameters.Should().Contain.One(x => x.Name == "@4" && x.Value.Equals(500));
        };
    }
}