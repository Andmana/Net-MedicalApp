--create database Med_341A
use Med_341A

-- Fadil 

DROP TABLE IF EXISTS m_admin
CREATE TABLE m_admin
(
    id          bigint primary key identity(1,1) not null,
    biodata_id  bigint null,
    code        varchar(10) null,
    created_by  bigint not null,
    created_on  datetime not null,
    modified_by bigint null,
    modified_on datetime null,
    deleted_by  bigint null,
    deleted_on  datetime null,
    is_delete   bit not null default 0
)
DROP TABLE IF EXISTS m_bank
CREATE TABLE m_bank
(
    id          bigint primary key identity(1,1) not null,
    name        varchar(100) null,
    va_code     varchar(10) null,
    created_by  bigint not null,
    created_on  datetime not null,
    modified_by bigint null,
    modified_on datetime null,
    deleted_by  bigint null,
    deleted_on  datetime null,
    is_delete   bit not null default 0
)
DROP TABLE IF EXISTS m_biodata
CREATE TABLE m_biodata
(
    id                  bigint primary key identity(1,1) not null,
    fullname            varchar(255) null,
    mobile_phone        varchar(15) null,
    image               varbinary(max) null,
    image_path          varchar(255) null,
    created_by          bigint not null,
    created_on          datetime not null,
    modified_by         bigint null,
    modified_on         datetime null,
    deleted_by          bigint null,
    deleted_on          datetime null,
    is_delete           bit not null default 0
)
DROP TABLE IF EXISTS m_biodata_address
CREATE TABLE m_biodata_address
(
    id                      bigint primary key identity(1,1) not null,
    biodata_id              bigint null,
    label                   varchar(100) null,
    recipent                varchar(100) null,
    recipent_phone_number   varchar(15) null,
    location_id             bigint null,
    postal_code             varchar(10) null,
    address                 text null,
    created_by              bigint not null,
    created_on              datetime not null,
    modified_by             bigint null,
    modified_on             datetime null,
    deleted_by              bigint null,
    deleted_on              datetime null,
    is_delete               bit not null default 0
)
DROP TABLE IF EXISTS m_blood_group
CREATE TABLE m_blood_group
(
    id                      bigint primary key identity(1,1) not null,
    code                    varchar(5) null,
    description             varchar(255) null,
    created_by              bigint not null,
    created_on              datetime not null,
    modified_by             bigint null,
    modified_on             datetime null,
    deleted_by              bigint null,
    deleted_on              datetime null,
    is_delete               bit not null default 0
)
DROP TABLE IF EXISTS m_courier
CREATE TABLE m_courier
(
    id                      bigint primary key identity(1,1) not null,
    name                    varchar(50) null,
    created_by              bigint not null,
    created_on              datetime not null,
    modified_by             bigint null,
    modified_on             datetime null,
    deleted_by              bigint null,
    deleted_on              datetime null,
    is_delete               bit not null default 0
)
DROP TABLE IF EXISTS m_courier_type
CREATE TABLE m_courier_type
(
    id                      bigint primary key identity(1,1) not null,
    courier_id              bigint null,
    name                    varchar(20) null,
    created_by              bigint not null,
    created_on              datetime not null,
    modified_by             bigint null,
    modified_on             datetime null,
    deleted_by              bigint null,
    deleted_on              datetime null,
    is_delete               bit not null default 0
)
DROP TABLE IF EXISTS t_courier_discount
CREATE TABLE t_courier_discount
(
    id                      bigint primary key identity(1,1) not null,
    courier_type_id         bigint null,
    value                   decimal null,
    created_by              bigint not null,
    created_on              datetime not null,
    modified_by             bigint null,
    modified_on             datetime null,
    deleted_by              bigint null,
    deleted_on              datetime null,
    is_delete               bit not null default 0
)
DROP TABLE IF EXISTS m_customer
CREATE TABLE m_customer
(
    id                      bigint primary key identity(1,1) not null,
    biodata_id              bigint null,
    dob                     date null,
    gender                  varchar(1) null,
    blood_group_id          bigint null,
    rhesus_type             varchar(5) null,
    height                  decimal null,
    weight                  decimal null,
    created_by              bigint not null,
    created_on              datetime not null,
    modified_by             bigint null,
    modified_on             datetime null,
    deleted_by              bigint null,
    deleted_on              datetime null,
    is_delete               bit not null default 0
)
DROP TABLE IF EXISTS m_customer_member
CREATE TABLE m_customer_member
(
    id                      bigint primary key identity(1,1) not null,
    parent_biodata_id       bigint null,
    customer_id             bigint null,
    customer_relation_id    bigint null,
    created_by              bigint not null,
    created_on              datetime not null,
    modified_by             bigint null,
    modified_on             datetime null,
    deleted_by              bigint null,
    deleted_on              datetime null,
    is_delete               bit not null default 0
)
DROP TABLE IF EXISTS m_customer_relation
CREATE TABLE m_customer_relation
(
    id                      bigint primary key identity(1,1) not null,
    name                    varchar(50) null,
    created_by              bigint not null,
    created_on              datetime not null,
    modified_by             bigint null,
    modified_on             datetime null,
    deleted_by              bigint null,
    deleted_on              datetime null,
    is_delete               bit not null default 0
)
DROP TABLE IF EXISTS m_doctor
CREATE TABLE m_doctor
(
    id                      bigint primary key identity(1,1) not null,
    biodata_id              bigint null,
    str                     varchar(50) null,
    created_by              bigint not null,
    created_on              datetime not null,
    modified_by             bigint null,
    modified_on             datetime null,
    deleted_by              bigint null,
    deleted_on              datetime null,
    is_delete               bit not null default 0
)

-- ANDREAS
DROP TABLE IF EXISTS m_doctor_education 
create table m_doctor_education (
    id BIGINT PRIMARY KEY IDENTITY(1, 1), 
    doctor_id BIGINT, 
    education_level_id BIGINT, 
    institution_name VARCHAR(100), 
    major VARCHAR(100), 
    start_year VARCHAR(4), 
    end_year VARCHAR(4), 
    is_last_education BIT DEFAULT 0,

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0 
  ) 

DROP TABLE IF EXISTS m_education_level 
create table m_education_level 
(
    id BIGINT PRIMARY KEY IDENTITY(1, 1), 
    name VARCHAR(10), 

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0
  ) 

DROP TABLE IF EXISTS m_location 
create table m_location 
(
    id bigint PRIMARY KEY IDENTITY(1, 1), 
    name varchar(100), 
    parent_id bigint, 
    location_level_id bigint, 

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0
  ) 

DROP TABLE IF EXISTS m_location_level 
create table m_location_level 
(
    id bigint PRIMARY KEY IDENTITY(1, 1), 
    name varchar(50), 
    abbreviation varchar(50), 

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0
  ) 

DROP TABLE IF EXISTS m_medical_facility 
create table m_medical_facility 
(
    id bigint PRIMARY KEY IDENTITY(1, 1), 
    name varchar(50), 
    medical_facility_category_id bigint, 
    location_id bigint, 
    full_address text, 
    email varchar (100), 
    phone_code varchar (10), 
    phone varchar (15), 
    fax varchar (15), 

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0
  ) 

DROP TABLE IF EXISTS m_medical_facility_category 
create table m_medical_facility_category 
(
    id bigint PRIMARY KEY IDENTITY(1, 1), 
    name varchar(50), 

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0
  ) 

DROP TABLE IF EXISTS m_medical_facility_schedule 
create table m_medical_facility_schedule 
(
    id bigint PRIMARY KEY IDENTITY(1, 1), 
    medical_facility_id bigint, 
    day varchar(10), 
    time_schedule_start varchar(10), 
    time_schedule_end varchar(10), 

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0
  ) 

DROP TABLE IF EXISTS m_medical_item 
create table m_medical_item 
(
    id bigint PRIMARY KEY IDENTITY(1, 1), 
    name varchar(50), 
    medical_item_category_id bigint, 
    composition text, 
    medical_item_segmentation_id bigint, 
    manufacturer varchar(100), 
    indication text, 
    dosage text, 
    directions text, 
    contraindication text, 
    caution text, 
    packaging varchar(50), 
    price_max bigint, 
    price_min bigint, 
    image VARBINARY(MAX), 
    image_path varchar(100), 

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0
  ) 

DROP TABLE IF EXISTS m_medical_item_category 
create table m_medical_item_category 
(
    id bigint PRIMARY KEY IDENTITY(1, 1), 
    name varchar(50), 

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0
  ) 

DROP TABLE IF EXISTS m_medical_item_segmentation 
create table m_medical_item_segmentation 
(
    id bigint PRIMARY KEY IDENTITY(1, 1), 
    name varchar(50), 

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0
  ) 

DROP TABLE IF EXISTS m_menu 
create table m_menu 
(
    id bigint PRIMARY KEY IDENTITY(1, 1), 
    name varchar (20), 
    url varchar (50), 
    parent_id bigint, 
    big_icon varchar(100), 
    small_icon varchar (100), 

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0
  )


DROP TABLE IF EXISTS m_menu_role
create table m_menu_role
(
    id bigint PRIMARY KEY IDENTITY(1, 1), 
    menu_id bigint, 
    role_id bigint, 

    created_by BIGINT NOT NULL, 
    created_on DATETIME NOT NULL, 
    modified_by BIGINT, 
    modified_on DATETIME, 
    deleted_by BIGINT, 
    deleted_on DATETIME, 
    is_delete BIT NOT NULL DEFAULT 0
  )

-- Vendra
DROP TABLE IF EXISTS m_payment_method
create table m_payment_method(
id bigint primary key identity(1,1),
name varchar(50) null,
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)
DROP TABLE IF EXISTS m_role
create table m_role(
id bigint primary key identity(1,1),
name varchar(20) null,
code varchar(20) null,
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)
DROP TABLE IF EXISTS m_specialization
create table m_specialization(
id bigint primary key identity(1,1),
name varchar(50) null,
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)
DROP TABLE IF EXISTS m_user
create table m_user(
id bigint primary key identity(1,1),
biodata_id bigint null,
role_id bigint null,
email varchar(100) null,
password varchar(255) null,
login_attempt int null,
is_locked bit null,
last_login datetime null,
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)
DROP TABLE IF EXISTS m_biodata_attachment
create table m_biodata_attachment(
id bigint primary key identity(1,1),
biodata_id bigint null,
file_name varchar(50) null,
file_path varchar(100) null,
file_size int null,
[file] VARBINARY(max) null,
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)
DROP TABLE IF EXISTS m_wallet_default_nominal
create table m_wallet_default_nominal(
id bigint primary key identity(1,1),
nominal int null,
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)
DROP TABLE IF EXISTS t_appointment
create table t_appointment(
id bigint primary key identity(1,1),
customer_id bigint null,
doctor_office_id bigint null,
doctor_office_schedule_id bigint null,
doctor_office_treatment_id bigint null,
appointment_date date null,
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)
DROP TABLE IF EXISTS t_appointment_cancellation
create table t_appointment_cancellation(
id bigint primary key identity(1,1),
appointment_id bigint null,
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)
DROP TABLE IF EXISTS t_appointment_done
create table t_appointment_done(
id bigint primary key identity(1,1),
appointment_id bigint null,
diagnosis varchar(100) not null, /* jika tidak diset panjangnya, maka panjang akan bernilai 1 */
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)
DROP TABLE IF EXISTS t_appointment_reschedule_history
create table t_appointment_reschedule_history(
id bigint primary key identity(1,1),
appointment_id bigint null,
doctor_office_schedule_id bigint null,
doctor_office_treatment_id bigint null,
appointment_date date null,
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)
DROP TABLE IF EXISTS t_current_doctor_specialization
create table t_current_doctor_specialization(
id bigint primary key identity(1,1),
doctor_id bigint null,
specialization_id bigint null,
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)
DROP TABLE IF EXISTS t_customer_chat
create table t_customer_chat(
id bigint primary key identity(1,1),
customer_id bigint null,
doctor_id bigint null,
created_by bigint not null,
created_on datetime not null,
modified_by bigint null,
modified_on datetime null,
deleted_by bigint null,
deleted_on datetime null,
is_delete bit not null)

-- Miko
DROP TABLE IF EXISTS t_customer_chat_history
CREATE TABLE t_customer_chat_history
(
    id							bigint primary key identity(1,1) not null,
    customer_chat_id            bigint null,
    chat_content				text null,
    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_customer_chat_nominal
CREATE TABLE t_customer_chat_nominal
(
    id							bigint primary key identity(1,1) not null,
    customer_id			bigint null,
    nominal				int null,
    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_customer_registered_card
CREATE TABLE t_customer_registered_card
(
    id							bigint primary key identity(1,1) not null,
    customer_id			bigint null,
    card_number 				varchar(20) null,
	validity_period date null,
	cvv varchar(5) null,
    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_customer_va
Create table t_customer_va
(
    id							bigint primary key identity(1,1) not null,
    customer_id			bigint null,
    va_number 				varchar(30) null,
	validity_period date null,
	cvv varchar(5) null,
    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_customer_va_history
Create table t_customer_va_history
(
    id							bigint primary key identity(1,1) not null,
    customer_va_id			bigint null,
    amount 				decimal null,
	expired_on datetime null,
	cvv varchar(5) null,
    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_customer_wallet
Create table t_customer_wallet
(
    id							bigint primary key identity(1,1) not null,
    customer_id			bigint null,
    pin 				varchar(6) null,
	balance decimal null,
	barcode varchar(50) null,
	points decimal null,
	pin_attempt int null,
	block_ends datetime null,
	is_blocked bit default 0,
    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_customer_wallet_topup
Create table t_customer_wallet_topup
(
    id							bigint primary key identity(1,1) not null,
    customer_wallet_id			bigint null,
    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_doctor_office
Create table t_doctor_office
(
    id							bigint primary key identity(1,1) not null,
	doctor_id					bigint null,
    medical_facilty_id			bigint null,
    specialization				varchar(100) not null,
	service_unit_id				bigint not null,
	start_date					date not null,
	end_date					date null,
    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_doctor_office_schedule
Create table t_doctor_office_schedule
(
    id							bigint primary key identity(1,1) not null,
    doctor_id			bigint null,
    medical_facility_schedule			bigint null,
   slot			int null,
    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_doctor_office_treatment
Create table t_doctor_office_treatment
(
    id							bigint primary key identity(1,1) not null,
    doctor_treatment_id			bigint null,
    doctor_office_id			bigint null,

    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_doctor_treatment
Create table t_doctor_treatment
(
    id							bigint primary key identity(1,1) not null,
    doctor_id			bigint null,
    name			varchar(50) null,

    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_medical_item_purchase
Create table t_medical_item_purchase
(
    id							bigint primary key identity(1,1) not null,
    customer_id					bigint null,
    payment_method_id			bigint null,

    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_medical_item_purchase_detail
Create table t_medical_item_purchase_detail
(
    id							bigint primary key identity(1,1) not null,
    medical_item_purchase_id	bigint null,
    medical_item_id				bigint null,
    qty							int null,
	medical_facility_id			bigint null,
	courier_id					bigint null,
	sub_total					decimal null,
    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_reset_password
Create table t_reset_password
(
    id							bigint primary key identity(1,1) not null,
    old_password					varchar(255) null,
	new_password					varchar(255) null,
    reset_for					varchar(20) null,


    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_token
Create table t_token
(
    id							bigint primary key identity(1,1) not null,
    email					varchar(100) null,
	user_id					bigint null,
	token varchar(50) null,
	expired_on datetime null,
	is_expired bit null,
	used_for varchar(20) null,

    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_treatment_discount
Create table t_treatment_discount
(
    id							bigint primary key identity(1,1) not null,
    doctor_office_treatment_price_id					varchar(100) null,
	value decimal null,

    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)
DROP TABLE IF EXISTS t_customer_wallet_withdraw
Create table t_customer_wallet_withdraw
(
    id							bigint primary key identity(1,1) not null,
    customer_id					bigint null,
	wallet_default_nominal_id bigint null,
	amount int null,
	bank_name varchar(50) null,
	account_number varchar(50) null,
	account_name varchar(255) null,
	otp int not null,

    created_by					bigint not null,
    created_on					datetime not null,
    modified_by					bigint null,
    modified_on					datetime null,
    deleted_by					bigint null,
    deleted_on					datetime null,
    is_delete					bit not null default 0
)









