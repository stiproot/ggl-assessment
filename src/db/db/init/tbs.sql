CREATE TABLE tb_img(
	id BIGINT PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	creation_timestamp_utc TIMESTAMP NOT NULL DEFAULT NOW(),
	usr_id BIGINT NOT NULL,
	inactive BOOLEAN NOT NULL DEFAULT FALSE,
	url VARCHAR(500) NOT NULL,
	thumbnail_url VARCHAR(500) NOT NULL
);

CREATE TABLE tb_usr(
	id BIGINT PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	creation_timestamp_utc TIMESTAMP NOT NULL DEFAULT NOW(),
	usr_id BIGINT NOT NULL,
	inactive BOOLEAN NOT NULL DEFAULT TRUE,
	usrname VARCHAR(50) NOT NULL UNIQUE,
	name VARCHAR(50) NOT NULL,
	surname VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL UNIQUE,
	pwd VARCHAR(25) NOT NULL
);

CREATE TABLE tb_product(
	id BIGINT PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	creation_timestamp_utc TIMESTAMP NOT NULL DEFAULT NOW(),
	usr_id BIGINT NOT NULL,
	inactive BOOLEAN NOT NULL DEFAULT FALSE,
	desc VARCHAR(250) NOT NULL,
	code VARCHAR(25) NOT NULL
);

CREATE TABLE tb_lst(
	id BIGINT PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	creation_timestamp_utc TIMESTAMP NOT NULL DEFAULT NOW(),
	usr_id BIGINT NOT NULL,
	inactive BOOLEAN NOT NULL DEFAULT FALSE,
	product_ids BIGINT[] NOT NULL,
	name VARCHAR(50) NOT NULL,
	FOREIGN KEY (usr_id) REFERENCES tb_usr(id) ON DELETE CASCADE
);

CREATE TABLE tb_product_img_mapping(
	id BIGINT PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	creation_timestamp_utc TIMESTAMP NOT NULL DEFAULT NOW(),
	usr_id BIGINT NOT NULL,
	inactive BOOLEAN NOT NULL DEFAULT FALSE,
	product_id BIGINT NOT NULL,
	img_id BIGINT NOT NULL,
	FOREIGN KEY (product_id) REFERENCES tb_product(id) ON DELETE CASCADE,
	FOREIGN KEY (img_id) REFERENCES tb_img(id) ON DELETE CASCADE,
	CONSTRAINT UC_PRODUCT_IMG_MAPPING UNIQUE (product_id, img_id)
);

CREATE TABLE tb_lst_status(
	id SMALLINT PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	creation_timestamp_utc TIMESTAMP NOT NULL DEFAULT NOW(),
	usr_id BIGINT NOT NULL,
	inactive BOOLEAN NOT NULL DEFAULT FALSE,
	desc VARCHAR(50) NOT NULL UNIQUE
);