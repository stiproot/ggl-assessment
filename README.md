# ggl-assessment

GGL SSD assessment.

# CORE USE-CASES

- OAuth2 integration
- Manage (shopping list) state

# DESIGN

## ERD
```mermaid
erDiagram
    tb_usr ||--o{ tb_lst : owns
    tb_usr {
        BIGINT id
        TIMESTAMP creation_timestamp_utc
        BIGINT usr_id
        BOOLEAN inactive
        VARCHAR(50) usrname
        VARCHAR(50) name
        VARCHAR(50) surname
        VARCHAR(50) email
        VARCHAR(25) pwd
    }

    tb_lst ||--o{ tb_product : contains
    tb_lst ||--o{ tb_lst_status : has
    tb_lst {
        BIGINT id
        TIMESTAMP creation_timestamp_utc
        BIGINT usr_id
        BOOLEAN inactive
        BIGINT[] product_ids
        VARCHAR(50) name
    }

    tb_lst_status {
        SMALLINT id
        TIMESTAMP creation_timestamp_utc
        BIGINT usr_id
        BOOLEAN inactive
        VARCHAR(50) desc
    }

    tb_product_img_mapping ||--o{ tb_product : maps
    tb_product_img_mapping ||--o{ tb_img : maps
    tb_product_img_mapping {
        BIGINT id
        TIMESTAMP creation_timestamp_utc
        BIGINT usr_id
        BOOLEAN inactive
        BIGINT product_id
        BIGINT img_id
    }

    tb_product {
        BIGINT id
        TIMESTAMP creation_timestamp_utc
        BIGINT usr_id
        BOOLEAN inactive
        VARCHAR(250) desc
        VARCHAR(25) code
    }

    tb_img {
        BIGINT id
        TIMESTAMP creation_timestamp_utc
        BIGINT usr_id
        BOOLEAN inactive
        VARCHAR(500) url
        VARCHAR(500) thumbnail_url
    }

```

## OAUTH (WORK IN PROGRESS...)

```mermaid
sequenceDiagram

  participant usr as User
  participant lstApi as List API
  participant db as Database
  participant files as Minio
  participant oauth2 as OAuth2 Provider

  usr ->>+ lstApi: << reg-req-payload: {email} >>
  lstApi ->>+ oauth2: << login-req >>
  oauth2 ->>+ usr: << prompt-user-to-login >>

```
