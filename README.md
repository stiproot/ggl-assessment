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
        VARCHAR(50) name
        VARCHAR(50) surname
        VARCHAR(50) email
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
        VARCHAR(50) description
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
        VARCHAR(250) description
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

    tb_ext_access_token {
        BIGINT id
        TIMESTAMP creation_timestamp_utc
        TIMESTAMP expiration_timestamp_utc
        BIGINT usr_id
        BOOLEAN inactive
        VARCHAR(500) token
        VARCHAR(500) refresh_token
    }

```

## REGISTRATION FLOW (OAUTH2)

```mermaid
sequenceDiagram

  participant usr as User
  participant ui as UI
  participant lstApi as List API
  participant google as Google OAuth2 API
  participant db as Database

  usr ->>+ ui: <<register>>
  ui ->>+ google: <<auth request>>
  google ->>+ lstApi: auth_code
  lstApi ->>+ google: <<get access token {auth_code}>>
  google ->>- lstApi: access_token, refresh_token
  lstApi ->>+ google: <<validtate access token {access_token}>>
  google ->>- lstApi: user_details
  lstApi ->>+ db: <<persist user>>
  db ->>- lstApi: key
  lstApi ->>+ db: persist refresh_token {key}
  db ->>- lstApi: key
  lstApi ->>+ lstApi: <<build jwt>>
  lstApi ->>- ui: jwt

```
