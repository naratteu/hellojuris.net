using System;
using static JurisJS;

class Program
{
    static void Main() => new Juris(new
    {
        components = new
        {
            App = new Func<dynamic, dynamic, object>((props, context) =>
            {
                var getState = context.getState;
                var setState = context.setState;
                return new
                {
                    render = new Func<object>(() => new
                    {
                        div = new
                        {
                            children = new object[]
                            {
                                    new { h1 = new { text = "Hello, Juris!" } },
                                    new {
                                        button = new
                                        {
                                            text = new Func<string>(() => $"Clicked {getState("count", 0)} times"),
                                            onclick = new Action(() => setState("count", getState("count", 0) + 1))
                                        }
                                    },
                                    new
                                    {
                                        p = new
                                        {
                                            children = new object[]
                                            {
                                                new { span = new{ text = "fork me! "} },
                                                new {
                                                    a = new{
                                                        text = "https://github.com/naratteu/hellojuris.net/tree/h5",
                                                        href = "https://github.com/naratteu/hellojuris.net/tree/h5"
                                                    }
                                                }
                                            }
                                        }
                                    }
                            }
                        }
                    })
                };
            })
        },
        layout = new { App = new { } }
    }).render("body");
}