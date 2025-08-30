namespace hellojuris.net;

using System.Runtime.InteropServices.JavaScript;

static partial class Juris
{
    [JSImport("bind", "Juris")] internal static partial JSObject Bind();
    [JSImport("prototype.render.call", "Juris")] internal static partial void Render(JSObject juris, string selector);
}

static partial class Window
{
    internal static partial class Object
    {
        [JSImport("Object.bind", "window")] internal static partial JSObject Bind();
    }
    internal static partial class Reflect
    {
        [JSImport("Reflect.construct", "window")] internal static partial JSObject Construct(JSObject @class, [JSMarshalAs<JSType.Array<JSType.Object>>] JSObject[] args);
        [JSImport("Reflect.set", "window")] internal static partial bool Set(JSObject obj, string key, [JSMarshalAs<JSType.Function>] Action value);
        [JSImport("Reflect.set", "window")] internal static partial bool Set(JSObject obj, string key, [JSMarshalAs<JSType.Array<JSType.Object>>] JSObject[] value);
        [JSImport("Reflect.set", "window")] internal static partial bool Set(JSObject obj, string key, [JSMarshalAs<JSType.Function<JSType.String>>] Func<string> value);
        [JSImport("Reflect.set", "window")] internal static partial bool Set(JSObject obj, string key, [JSMarshalAs<JSType.Function<JSType.Object>>] Func<JSObject> value);
        [JSImport("Reflect.set", "window")] internal static partial bool Set(JSObject obj, string key, [JSMarshalAs<JSType.Function<JSType.Object, JSType.Object, JSType.Object>>] Func<JSObject, JSObject, JSObject> value);

        [return: JSMarshalAs<JSType.Function<JSType.String, JSType.Any, JSType.Any>>]
        [JSImport("Reflect.get", "window")] internal static partial Func<string, object, object> Get(JSObject obj, string key);
    }
}