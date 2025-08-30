using System.Runtime.InteropServices.JavaScript;
using hellojuris.net;
using Microsoft.Extensions.DependencyInjection;

[assembly: System.Runtime.Versioning.SupportedOSPlatform("browser")]

using var sp = new ServiceCollection()
    .AddKeyedSingleton<JSObject>("Juris", Juris.Bind())
    .AddKeyedSingleton<JSObject>("Window.Object", Window.Object.Bind())
    .AddKeyedTransient<JSObject>("{}", (p, _) => Window.Reflect.Construct(p.GetRequiredKeyedService<JSObject>("Window.Object"), []))
    .BuildServiceProvider();
Func<JSObject> p = () => sp.GetRequiredKeyedService<JSObject>("{}");

Func<JSObject, JSObject, JSObject> App = (props, context) =>
{
    var getState = Window.Reflect.Get(context, "getState");
    var setState = Window.Reflect.Get(context, "setState");
    return new Obj(p).With("render", () =>
    {
        return new Obj(p).With("div", new Obj(p).With("children", [
            new Obj(p).With("h1", new Obj(p)
                .With("text", "Hello, Juris!")),
            new Obj(p).With("button", new Obj(p)
                .With("text", () => $"Clicked {getState("count", 0)} times")
                .With("onclick", () => setState("count", (double)getState("count", 0) + 1))),
            new Obj(p).With("p", new Obj(p).With("children", [
                new Obj(p).With("span", new Obj(p).With("text", "fork me! ")),
                new Obj(p).With("a", new Obj(p)
                    .With("text", "https://github.com/naratteu/hellojuris.net")
                    .With("href", "https://github.com/naratteu/hellojuris.net")),
            ])),
        ]));
    });
};

using var juris = Window.Reflect.Construct(sp.GetRequiredKeyedService<JSObject>("Juris"), [
    new Obj(p)
        .With("components", new Obj(p).With("App", App))
        .With("layout", new Obj(p).With("App", new Obj(p)))
]);

Juris.Render(juris, "#app");

class Obj(Func<JSObject> p)
{
    readonly JSObject JSObject = p();
    public static implicit operator JSObject(Obj obj) => obj.JSObject;

    internal Obj With(string key, string value) { JSObject.SetProperty(key, value); return this; }
    internal Obj With(string key, JSObject value) { JSObject.SetProperty(key, value); return this; }
    internal Obj With(string key, Action value) { Window.Reflect.Set(JSObject, key, value); return this; }
    internal Obj With(string key, Func<string> value) { Window.Reflect.Set(JSObject, key, value); return this; }
    internal Obj With(string key, Func<JSObject> value) { Window.Reflect.Set(JSObject, key, value); return this; }
    internal Obj With(string key, Func<JSObject, JSObject, JSObject> value) { Window.Reflect.Set(JSObject, key, value); return this; }
    internal Obj With(string key, JSObject[] value) { Window.Reflect.Set(JSObject, key, value); return this; }
}