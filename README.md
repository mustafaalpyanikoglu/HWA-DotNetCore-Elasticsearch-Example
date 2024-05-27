# .NET Core 7 ElasticSearch Demo

Bu proje, .NET Core 7 ile ElasticSearch'in nasıl kullanılacağını göstermektedir. ElasticSearch'te depolanan belgeler üzerinde CRUD işlemlerini gerçekleştirmek için basit bir API sağlar.

## Önkoşullar

- .NET Core 7 SDK
- Çalışan bir ElasticSearch örneği (Elastic Cloud'u kullanabilir veya ElasticSearch'i [yerel olarak kurabilirsiniz](https://www.elastic.co/downloads/elasticsearch))
- ElasticSearch bağlantı detaylarını içeren yapılandırma dosyası (`appsettings.json`)

## Kurulum

1. Depoyu klonlayın.
2. ElasticSearch bağlantı detaylarınızı `appsettings.json` dosyasında yapılandırın.
3. .NET CLI kullanarak çözümü derleyin.
4. Uygulamayı çalıştırın.

## Yapılandırma

Aşağıdaki yapıya sahip bir yapılandırma dosyanız (`appsettings.json`) olduğundan emin olun:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ElasticSearchConfig": {
    "ConnectionString": "ELASTICSEARCH_BAĞLANTI_DİZGESİNİZ",
    "Username": "ELASTICSEARCH_KULLANICI_ADI",
    "Password": "ELASTICSEARCH_ŞİFRE",
    "DisableCertificateValidation": true,
    "IndexName": "İNDEKS_ADINIZ"
  },
  "AllowedHosts": "*"
}
```
"ELASTICSEARCH_BAĞLANTI_DİZGESİNİZ", "ELASTICSEARCH_KULLANICI_ADI", "ELASTICSEARCH_ŞİFRE" ve "İNDEKS_ADINIZ" kısımlarını kendi ElasticSearch bağlantı detaylarınızla değiştirin.

# ELASTICSEARCH API

API aşağıdaki uç noktaları sağlar:

- `POST /api/ElasticSearch`: Yeni bir belge oluşturun.
- `PUT /api/ElasticSearch`: Varolan bir belgeyi güncelleyin.
- `DELETE /api/ElasticSearch/{id}`: Bir belgeyi ID'ye göre silin.
- `GET /api/ElasticSearch/{id}`: Bir belgeyi ID'ye göre alın.
- `GET /api/ElasticSearch`: Tüm belgeleri alın.

## Proje Yapısı

- `ElasticSearchController.cs`: ElasticSearch işlemlerini işlemek için denetleyici.
- `ElasticsearchServiceRegistration.cs`: ElasticSearch hizmetlerini kaydetmek için uzantı yöntemi.
- `ElasticSearchConfig.cs`: ElasticSearch yapılandırması için model sınıfı.
- `ElasticSearchService.cs`: ElasticSearch hizmetinin uygulaması.
- `IElasticSearchService.cs`: ElasticSearch hizmeti için arabirim.
- `MyDocument.cs`: Bir belgeyi temsil eden model sınıfı.

## Bağımlılıklar

- Nest: ElasticSearch için .NET istemcisi.

## Katkıda Bulunma

Katkılarınızı bekliyoruz! Herhangi bir sorun bulursanız veya önerileriniz varsa, lütfen bir sorun açın veya bir çekme isteği oluşturun.

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır - ayrıntılar için LICENSE dosyasına bakın.
