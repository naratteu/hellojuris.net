# hellojuris.net
[juris.js](https://jurisjs.com/) + dotnet webassembly

## Run

```bash
dotnet watch --no-hot-reload
```

## Publish

```bash
dotnet publish -o bin/pub
ipfs add -Qr bin/pub/wwwroot # QmPh8X2iAzhSiG8CDPLy8b7NbR6M2rPevgcbJMji9yV4At
ipfs daemon & ipfs routing provide QmPh8X2iAzhSiG8CDPLy8b7NbR6M2rPevgcbJMji9yV4At
```
https://ipfs.io/ipfs/QmPh8X2iAzhSiG8CDPLy8b7NbR6M2rPevgcbJMji9yV4At

## 평가

닷넷 웹어셈블리가 `PublishAot` 컴파일을 지원하지 않는다고 하나 11.5MB 정도의 출력 용량으로 동작하는것을 봤을때 상응하는 Trimming처리는 되는걸로 보임.

`juris.js`가 jsx따위의 문법 없이 dom을 구성하는것에 C#의 강타입 json직렬화를 이용해보고자 구상한것이나, 콜백등의 이벤트 핸들링을 위해서는 `Json`문자열이 아니라 `JsObject`를 메모리단에서 직접 핸들링 해야 가능한것임을 뒤늦게 깨달음..

추후 강타입의 혜택을 볼수있을법한 `juris.js` -> `juris.d.ts` -> `juris.net` wrapper를 만들 수 있을법 해보이나 스크립트의 자유로운 문법을 소화하기 위한 온갖 추상화부터 쉽지않을걸로 보임.

`C#` 코드에서 사용하는 온갖 `JsObject`를 `DI`를 통해 일괄 관리 할 수 있도록 구성했으나, 애초체 js라이브러리를 억지로 c#에서 다루기위해 사실상 모든 객체를 불필요하게 불러오고 해제해야만 하고있는 구조부터 해소될 필요가 있음.