# 📅 TODO API - Clean Architecture (.NET 9)

Bu proje, **Doğuş Teknoloji Geleceğe Giriş Programı** kapsamında, Emre Uslu tarafından Clean Architecture mimarisi temelinde tasarlanan bir TODO API uygulamasıdır.

## 🎓 Amaç

Kullanıcıların görevlerini yönetmesine olanak tanıyan, çağdaş yazılım mimari prensipleriyle inşa edilmiş bir RESTful API sunmaktadır.

---

## 🪓 Kullanılan Teknolojiler

| Teknoloji          | Amaç                            |
| ------------------ | ------------------------------- |
| .NET 9             | Backend API geliştirme          |
| EF Core            | ORM katmanı                     |
| SQLite             | Veritabanı olarak               |
| MediatR            | CQRS ve handler yapısı          |
| FluentValidation   | Girdi/doğrulama kuralları       |
| Clean Architecture | Proje yapısında çekirdek ayrımı |

---

## 📊 Veritabanı Modeli

Her bir TODO şu alanlardan oluşur:

```csharp
public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
```

---

## 🔄 API Endpointleri

### 1. Tüm Görevleri Listele

```http
GET /api/todos
```

**Opsiyonel sorgular**:

* `isCompleted` (bool)
* `dueBefore` (DateTime)
* `pageNumber`, `pageSize`

---

### 2. Belirli Bir Görevi Getir

```http
GET /api/todos/{id}
```

---

### 3. Yeni Görev Oluştur

```http
POST /api/todos
```

#### Örnek Body:

```json
{
  "title": ".NET Kurslarını Bitir",
  "description": "Yöneticinin atadığı kurslar bitirilecek",
  "dueDate": "2025-07-12T00:00:00Z"
}
```

---

### 4. Görevi Güncelle (Tüm Alanlar)

```http
PUT /api/todos/{id}
```

---

### 5. Görevi Kısmi Güncelle (PATCH)

```http
PATCH /api/todos/{id}
```

#### Örnek:

```json
{
  "id": 5,
  "isCompleted": true
}
```

---

### 6. Görev Sil

```http
DELETE /api/todos/{id}
```

---

## 👤 Kullanıcı Senaryosu

* Yeni bir TODO oluştur.
* Belirli bir tarih öncesindeki tamamlanmamış TODO'ları listele.
* Bir TODO'nun yalnızca `IsCompleted` alanını `true` yap.
* Eski görevleri sil.

---

## 📷 Ekran Görüntüsü

> ⚠️ Görsel eklemek için bu alana API test ekranından veya Swagger arayüzünden bir screenshot yerleştirilebilir.

---

## 🔧 Projeyi Çalıştırmak

1. Bu repoyu klonlayın:

```bash
git clone https://github.com/kullaniciadi/TodoAPI.git
```

2. Bağımlılıkları yükleyin:

```bash
dotnet restore
```

3. Veritabanını oluşturun:

```bash
dotnet ef database update --project Todo.Infrastructure
```

4. API'yi çalıştırın:

```bash
dotnet run --project Todo.API
```

---

## 🌟 Katkı

Bu proje bireysel gelişim ve Clean Architecture öğrenimi için kullanılmaktadır. Dilerseniz forku alarak kendi öğrenme deneyiminizi sürdürebilirsiniz.

---

## 🚀 Hedefler

* [x] CRUD operasyonları
* [x] Pagination, filtreleme
* [x] PATCH desteği (kısmi güncelleme)
* [ ] Authentication/Authorization (isteğe bağlı)
* [ ] Unit test kapsamı
