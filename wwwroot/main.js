import { dotnet } from './_framework/dotnet.js'
import { Juris } from "https://esm.sh/juris";

const { setModuleImports, runMain } = await dotnet.create();

setModuleImports('Juris', Juris);
setModuleImports('window', window);
await runMain();