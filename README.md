# hellojuris.net
[juris.js](https://jurisjs.com/) + dotnet [h5](https://github.com/curiosity-ai/h5)

## Publish

```bash
dotnet build
ipfs add -Qr bin/Debug/netstandard2.0/h5 # print cid
ipfs daemon & ipfs routing provide # ..cid
```

## 평가

`dynamic`이 이렇게 유용했던적이 없음.