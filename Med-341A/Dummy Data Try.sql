-- TESTING DATA DOKTER

INSERT INTO m_specialization
VALUES
    ('bedah', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('penyakit dalam', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('gastroenterologi dan hepatologi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('alergi dan imunologi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('endokrin', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('ginjal dan hipertensi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('jantung dan pembuluh darah', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('paru', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('anak', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('saraf', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('kandungan dan ginekologi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('kulit dan kelamin', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('andrologi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('THT', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('mata', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('Psikiater', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('penyakit mulut', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('gizi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('urologi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0);


INSERT INTO m_location_level
VALUES
    ('Provinsi', 'PRV', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('Kota/Kabupaten', 'KTK', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('Kecamatan', 'KCM', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    ('Kelurahan', 'KLH', 1, GETDATE(), NULL, NULL, NULL, NULL, 0);


INSERT INTO m_location
    (name, location_level_id, created_on, created_by, modified_on, modified_by, deleted_on, deleted_by, is_delete)
VALUES
    ('Kota Jakarta Pusat', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kota Jakarta Selatan', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kota Jakarta Barat', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kota Jakarta Timur', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kota Jakarta Utara', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kabupaten Bogor', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kota Bogor', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kabupaten Bekasi', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kota Bekasi', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kabupaten Tangerang', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kota Tangerang', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kota Tangerang Selatan', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kabupaten Bandung', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kota Bandung', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kabupaten Garut', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kabupaten Sukabumi', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kota Sukabumi', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kabupaten Cianjur', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kabupaten Cirebon', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kota Cirebon', 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0);

INSERT INTO m_location
    (name, parent_id, location_level_id, created_on, created_by, modified_on, modified_by, deleted_on, deleted_by, is_delete)
VALUES
    ('Gambir', 1, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Tanah Abang', 1, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Senen', 1, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Menteng', 2, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Setiabudi', 2, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kebayoran Baru', 2, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Palmerah', 3, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Cengkareng', 3, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Kramat Jati', 4, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Matraman', 4, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Koja', 5, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Pademangan', 5, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Bogor Utara', 7, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Bogor Selatan', 7, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    -- Tambahkan lebih banyak kecamatan hingga mencapai minimal 50 data
    ('Bekasi Utara', 9, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Bekasi Selatan', 9, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Tangerang', 11, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Pamulang', 12, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Bandung Kulon', 14, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0),
    ('Lengkong', 14, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0);


SELECT
    CONCAT(kecamatan.name, ', ', kota.name) AS gabungan
FROM
    m_location AS kecamatan
    JOIN
    m_location AS kota ON kecamatan.parent_id = kota.id
WHERE 
    kecamatan.location_level_id = 3 -- Level untuk Kecamatan
    AND kota.location_level_id = 2-- Level untuk Kota/Kabupaten
;


INSERT INTO m_medical_facility
    (name, medical_facility_category_id, location_id, full_address, email, phone_code, phone, fax, created_by, created_on, modified_by, modified_on, deleted_by, deleted_on, is_delete)
VALUES
    --1
    ('RS Jakarta Pusat', 1, 21, 'Jl. Medan Merdeka No.1, Gambir, Jakarta Pusat', 'info@rsjakartapusat.com', '021', '1234567', '1234568', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --2
    ('RS Jakarta Selatan', 1, 24, 'Jl. Gatot Subroto No.10, Setiabudi, Jakarta Selatan', 'info@rsjakartaselatan.com', '021', '2345678', '2345679', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --3
    ('RS Bogor', 1, 33, 'Jl. Pajajaran No.50, Bogor Utara, Bogor', 'info@rsbogor.com', '0251', '3456789', '3456790', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --4
    ('RS Bekasi', 1, 35, 'Jl. Ahmad Yani No.20, Bekasi Utara, Bekasi', 'info@rsbekasi.com', '021', '4567890', '4567891', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --5
    ('RS Tangerang', 1, 37, 'Jl. Merdeka No.15, Tangerang', 'info@rstangerang.com', '021', '5678901', '5678902', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --6
    ('RS Bandung', 1, 39, 'Jl. Asia Afrika No.23, Bandung Kulon, Bandung', 'info@rsbandung.com', '022', '6789012', '6789013', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --7
    ('Klinik Cengkareng', 2, 28, 'Jl. Daan Mogot No.30, Cengkareng, Jakarta Barat', 'info@klinikcengkareng.com', '021', '7890123', '7890124', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --8
    ('Klinik Menteng', 2, 24, 'Jl. HOS Cokroaminoto No.25, Menteng, Jakarta Pusat', 'info@klinikmenteng.com', '021', '8901234', '8901235', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --9
    ('Puskesmas Palmerah', 3, 27, 'Jl. Kemanggisan No.10, Palmerah, Jakarta Barat', 'info@puskesmaspalmerah.com', '021', '9012345', '9012346', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --10
    ('Puskesmas Setiabudi', 3, 25, 'Jl. Rasuna Said No.12, Setiabudi, Jakarta Selatan', 'info@puskesmassetiabudi.com', '021', '0123456', '0123457', 1, GETDATE(), NULL, NULL, NULL, NULL, 0);

INSERT INTO m_medical_facility
    (name, medical_facility_category_id, location_id, full_address, email, phone_code, phone, fax, created_by, created_on, modified_by, modified_on, deleted_by, deleted_on, is_delete)
VALUES
    --11
    ('RSUD Depok', 1, 34, 'Jl. Margonda Raya No.12, Pancoran Mas, Depok', 'info@rsuddepok.com', '021', '1122334', '1122335', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --12
    ('RS Cipto Mangunkusumo', 1, 23, 'Jl. Pangeran Diponegoro No.15, Senen, Jakarta Pusat', 'info@rscm.com', '021', '2233445', '2233446', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --13
    ('RS Siloam Karawaci', 1, 37, 'Jl. Boulevard Diponegoro No.17, Karawaci, Tangerang', 'info@siloamkarawaci.com', '021', '3344556', '3344557', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --14
    ('RS Hermina Bekasi', 1, 36, 'Jl. Kemakmuran No.39, Bekasi Selatan, Bekasi', 'info@herminabekasi.com', '021', '4455667', '4455668', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --15
    ('RS Mayapada Lebak Bulus', 1, 26, 'Jl. Lebak Bulus Raya No.20, Cilandak, Jakarta Selatan', 'info@mayapadalebakbulus.com', '021', '5566778', '5566779', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --16
    ('Klinik Utama Harapan Indah', 2, 36, 'Jl. Harapan Indah No.8, Medan Satria, Bekasi', 'info@klinikutama.com', '021', '6677889', '6677890', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --17
    ('Klinik Medika Cikarang', 2, 35, 'Jl. Raya Industri No.5, Cikarang Utara, Bekasi', 'info@klinikmedikacikarang.com', '021', '7788990', '7788991', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --18
    ('Puskesmas Sukmajaya', 3, 33, 'Jl. Raya Bogor No.10, Sukmajaya, Depok', 'info@puskesmassukmajaya.com', '021', '8899001', '8899002', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --19
    ('Puskesmas Pasar Minggu', 3, 24, 'Jl. Raya Pasar Minggu No.3, Pasar Minggu, Jakarta Selatan', 'info@puskesmaspasarminggu.com', '021', '9900112', '9900113', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --20
    ('RSUD Tangerang Selatan', 1, 37, 'Jl. Ciater Barat No.7, Serpong, Tangerang Selatan', 'info@rsudtangsel.com', '021', '1011122', '1011123', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --21
    ('RSUD Bandung', 1, 39, 'Jl. Alun-Alun Timur No.4, Bandung', 'info@rsudbandung.com', '022', '2021223', '2021224', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --22
    ('RSIA Melati', 1, 40, 'Jl. Setiabudi No.9, Bandung', 'info@rsiamelati.com', '022', '3031334', '3031335', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --23
    ('Klinik Mitra Sehat', 2, 33, 'Jl. Bogor Raya No.20, Bogor Tengah, Bogor', 'info@klinikmitrasehat.com', '0251', '4142434', '4142435', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --24
    ('Klinik Sejahtera Medika', 2, 37, 'Jl. Raya Serang No.11, Karawaci, Tangerang', 'info@kliniksejahteramedika.com', '021', '5152535', '5152536', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    --25
    ('Puskesmas Gunung Putri', 3, 33, 'Jl. Raya Gunung Putri No.6, Gunung Putri, Bogor', 'info@puskesmasgunungputri.com', '0251', '6162636', '6162637', 1, GETDATE(), NULL, NULL, NULL, NULL, 0);

INSERT INTO m_medical_facility
    (name, medical_facility_category_id, location_id, full_address, email, phone_code, phone, fax, created_by, created_on, modified_by, modified_on, deleted_by, deleted_on, is_delete)
VALUES
    -- 26
    ('Rumah Sakit Xsis', 3, 26, 'Jl. Langsat No.10, Kebayoran Baru, Jakarta Selatan', 'info@rumahsakitxsis.com', '021', '9012345', '9012346', 1, GETDATE(), NULL, NULL, NULL, NULL, 0);

UPDATE m_medical_facility SET medical_facility_category_id=4 WHERE id=26

SELECT *
FROM m_medical_facility
    JOIN m_medical_facility_category ON m_medical_facility.medical_facility_category_id = m_medical_facility_category.id
WHERE medical_facility_category_id=4;

INSERT INTO m_medical_facility_category
    (name, created_by, created_on, is_delete)
VALUES
    ('Rumah Sakit', 1, GETDATE(), 0),
    ('Klinik', 1, GETDATE(), 0),
    ('Puskesmas', 1, GETDATE(), 0);

INSERT INTO m_biodata
    (fullname, mobile_phone, image, image_path, created_by, created_on, is_delete)
VALUES
    ('Dr. Ahmad Susanto Sp.B', '08123456789', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Budi Hartono Sp.PD', '08129876543', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Citra Dewi Sp.PD-KGEH', '08122334455', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Dedi Wijaya Sp.PD-KAI', '08124567890', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Erna Sari Sp.PD-KEMD', '08121234567', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Fajar Pratama Sp.PD-KGH', '08127894561', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Gita Permana Sp. JP', '08123451234', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Herman Suryadi Sp.And', '08129876547', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Indah Pertiwi Sp.S Sp.N', '08124561234', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Joko Santoso SpKK', '08128975632', NULL, NULL, 1, GETDATE(), 0);

INSERT INTO m_biodata
    (fullname, mobile_phone, image, image_path, created_by, created_on, is_delete)
VALUES
    ('Dr. Joko Santoso Sp.A', '08128975632', NULL, NULL, 1, GETDATE(), 0);


INSERT INTO m_doctor
    (biodata_id, str, created_by, created_on, is_delete)
VALUES
    (1, 'STR-2023-0001', 1, GETDATE(), 0),
    (2, 'STR-2023-0002', 1, GETDATE(), 0),
    (3, 'STR-2023-0003', 1, GETDATE(), 0),
    (4, 'STR-2023-0004', 1, GETDATE(), 0),
    (5, 'STR-2023-0005', 1, GETDATE(), 0),
    (6, 'STR-2023-0006', 1, GETDATE(), 0),
    (7, 'STR-2023-0007', 1, GETDATE(), 0),
    (8, 'STR-2023-0008', 1, GETDATE(), 0),
    (9, 'STR-2023-0009', 1, GETDATE(), 0),
    (10, 'STR-2023-0010', 1, GETDATE(), 0);

INSERT INTO t_doctor_office
    (doctor_id, medical_facilty_id, specialization, start_date, end_date, service_unit_id, created_by, created_on, is_delete)
VALUES
    (1, 1, 'spesialis bedah', '2020-01-01', NULL, 1, 1, GETDATE(), 0),
    (2, 2, 'spesialis penyakit dalam', '2019-07-01', NULL, 1, 1, GETDATE(), 0),
    (3, 8, 'spesialis ortopedi', '2018-02-01', NULL, 2, 1, GETDATE(), 0),
    (4, 10, 'spesialis saraf', '2015-11-01', NULL, 2, 1, GETDATE(), 0),
    (5, 9, 'spesialis anak', '2016-12-11', NULL, 3, 1, GETDATE(), 0),
    (6, 8, 'spesialis jantung dan pembuluh darah', '2014-05-01', NULL, 4, 1, GETDATE(), 0),
    (7, 9, 'spesialis THT', '2014-04-01', NULL, 3, 1, GETDATE(), 0),
    (8, 9, 'spesialis paru', '2019-06-01', NULL, 4, 1, GETDATE(), 0),
    (9, 2, 'spesialis urologi', '2010-08-01', NULL, 5, 1, GETDATE(), 0),
    (10, 15, 'spesialis gizi', '2020-09-01', NULL, 5, 1, GETDATE(), 0),
    (11, 1, 'spesialis paru', '2015-10-01', NULL, 1, 1, GETDATE(), 0),
    (12, 2, 'spesialis paru', '2011-11-01', NULL, 1, 1, GETDATE(), 0),
    (13, 8, 'spesialis paru', '2015-12-01', NULL, 1, 1, GETDATE(), 0),
    (14, 10, 'spesialis paru', '2020-03-11', NULL, 1, 1, GETDATE(), 0),
    (15, 9, 'spesialis paru', '2021-11-01', NULL, 1, 1, GETDATE(), 0),
    (16, 8, 'spesialis paru', '2022-01-01', NULL, 1, 1, GETDATE(), 0),
    (17, 9, 'spesialis paru', '2014-05-01', NULL, 1, 1, GETDATE(), 0),
    (18, 9, 'spesialis paru', '2018-10-01', NULL, 1, 1, GETDATE(), 0),
    (19, 2, 'spesialis paru', '2019-09-01', NULL, 1, 1, GETDATE(), 0),
    (20, 2, 'spesialis paru', '2020-11-01', NULL, 1, 1, GETDATE(), 0);

INSERT INTO t_doctor_office
    (doctor_id, medical_facilty_id, specialization, start_date, end_date, service_unit_id, created_by, created_on, is_delete)
VALUES
    (2, 8, 'spesialis bedah', '2018-12-12', NULL, 5, 1, GETDATE(), 0);

INSERT INTO t_doctor_office
    (doctor_id, medical_facilty_id, specialization, start_date, end_date, service_unit_id, created_by, created_on, is_delete)
VALUES
    (20, 20, 'spesialis paru', '2020-08-01', NULL, 1, 1, GETDATE(), 0);

INSERT INTO t_doctor_office
    (doctor_id, medical_facilty_id, specialization, start_date, end_date, service_unit_id, created_by, created_on, is_delete)
VALUES
    (21, 2, 'spesialis Anak', '2020-09-01', NULL, 1, 1, GETDATE(), 0);

INSERT INTO t_doctor_office
    (doctor_id, medical_facilty_id, specialization, start_date, end_date, service_unit_id, created_by, created_on, is_delete)
VALUES
    (21, 2, 'spesialis Anak', '2020-09-01', NULL, 1, 1, GETDATE(), 0);

INSERT INTO t_doctor_office
    (doctor_id, medical_facilty_id, specialization, start_date, end_date, service_unit_id, created_by, created_on, is_delete)
VALUES
    (1, 7, 'spesialis bedah', '2023-09-01', NULL, 1, 1, GETDATE(), 0)

INSERT INTO t_doctor_office
    (doctor_id, medical_facilty_id, specialization, start_date, end_date, service_unit_id, created_by, created_on, is_delete)
VALUES
    (2, 13, 'spesialis penyakit dalam', '2019-07-01', NULL, 1, 1, GETDATE(), 0),
    (3, 12, 'gastroenterologi dan hepatologi', '2018-02-01', NULL, 2, 1, GETDATE(), 0),
    (4, 15, 'alergi dan imunologi', '2015-11-01', NULL, 2, 1, GETDATE(), 0),
    (5, 11, 'spesialis endokrin', '2016-12-11', NULL, 3, 1, GETDATE(), 0),
    (6, 14, 'spesialis ginjal dan hipertensi', '2014-05-01', NULL, 4, 1, GETDATE(), 0),
    (7, 22, 'spesialis jantung dan pembuluh darah', '2014-04-01', NULL, 3, 1, GETDATE(), 0),
    (8, 3, 'spesialis andrologi', '2019-06-01', NULL, 4, 1, GETDATE(), 0),
    (9, 23, 'spesialis saraf', '2010-08-01', NULL, 5, 1, GETDATE(), 0),
    (10, 24, 'spesialis kulit dan kelamin', '2020-09-01', NULL, 5, 1, GETDATE(), 0),
    (11, 7, 'spesialis paru', '2015-10-01', NULL, 1, 1, GETDATE(), 0),
    (12, 10, 'spesialis paru', '2011-11-01', NULL, 1, 1, GETDATE(), 0),
    (13, 14, 'spesialis paru', '2015-12-01', NULL, 1, 1, GETDATE(), 0),
    (14, 4, 'spesialis paru', '2020-03-11', NULL, 1, 1, GETDATE(), 0),
    (15, 3, 'spesialis paru', '2021-11-01', NULL, 1, 1, GETDATE(), 0),
    (16, 6, 'spesialis paru', '2022-01-01', NULL, 1, 1, GETDATE(), 0),
    (17, 11, 'spesialis paru', '2014-05-01', NULL, 1, 1, GETDATE(), 0),
    (18, 5, 'spesialis paru', '2018-10-01', NULL, 1, 1, GETDATE(), 0),
    (19, 10, 'spesialis paru', '2019-09-01', NULL, 1, 1, GETDATE(), 0),
    (21, 16, 'spesialis anak', '2020-11-01', NULL, 1, 1, GETDATE(), 0)



INSERT INTO t_current_doctor_specialization
    (doctor_id, specialization_id, created_by, created_on, is_delete)
VALUES
    (1, 1, 1, GETDATE(), 0),
    (2, 2, 1, GETDATE(), 0),
    (3, 3, 1, GETDATE(), 0),
    (4, 4, 1, GETDATE(), 0),
    (5, 5, 1, GETDATE(), 0),
    (6, 6, 1, GETDATE(), 0),
    (7, 7, 1, GETDATE(), 0),
    (8, 13, 1, GETDATE(), 0),
    (9, 10, 1, GETDATE(), 0),
    (10, 12, 1, GETDATE(), 0);

INSERT INTO t_doctor_treatment
    (doctor_id, name, created_by, created_on, is_delete)
VALUES
    (1, 'Appendektomi', 1, GETDATE(), 0),
    (1, 'Laparoskopi', 1, GETDATE(), 0),
    (2, 'Manajemen Diabetes', 1, GETDATE(), 0),
    (3, 'Penanganan Patah Tulang', 1, GETDATE(), 0),
    (4, 'Penanganan Stroke', 1, GETDATE(), 0),
    (5, 'Vaksinasi Anak', 1, GETDATE(), 0),
    (6, 'Kateterisasi Jantung', 1, GETDATE(), 0),
    (7, 'Operasi Amandel', 1, GETDATE(), 0),
    (8, 'Penanganan Tuberkulosis', 1, GETDATE(), 0),
    (9, 'Operasi Batu Ginjal', 1, GETDATE(), 0),
    (10, 'Konsultasi Gizi untuk Diet', 1, GETDATE(), 0);



-- Data Baru
INSERT INTO m_biodata
    (fullname, mobile_phone, image, image_path, created_by, created_on, is_delete)
VALUES
    ('Dr. Ali Suroto Sp.P', '08123456701', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Rina Melati Sp.P', '08123456702', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Sandi Kurniawan Sp.P', '08123456703', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Tania Rizky Sp.P', '08123456704', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Wira Ramadhan Sp.P', '08123456705', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Dinda Arini Sp.P', '08123456706', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Fadli Prasetyo Sp.P', '08123456707', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Indah Setiawati Sp.P', '08123456708', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Jaka Prabowo Sp.P', '08123456709', NULL, NULL, 1, GETDATE(), 0),
    ('Dr. Maya Sari Sp.P', '08123456710', NULL, NULL, 1, GETDATE(), 0);

SELECT *
FROM m_biodata

UPDATE m_biodata SET fullname='Dr. Ratno Wijaya Sp.A' WHERE id=11;

INSERT INTO m_doctor
    (biodata_id, str, created_by, created_on, is_delete)
VALUES
    (11, 'STR-2024-0001', 1, GETDATE(), 0),
    (12, 'STR-2024-0002', 1, GETDATE(), 0),
    (13, 'STR-2024-0003', 1, GETDATE(), 0),
    (14, 'STR-2024-0004', 1, GETDATE(), 0),
    (15, 'STR-2024-0005', 1, GETDATE(), 0),
    (16, 'STR-2024-0006', 1, GETDATE(), 0),
    (17, 'STR-2024-0007', 1, GETDATE(), 0),
    (18, 'STR-2024-0008', 1, GETDATE(), 0),
    (19, 'STR-2024-0009', 1, GETDATE(), 0),
    (20, 'STR-2024-0010', 1, GETDATE(), 0);


INSERT INTO m_doctor
    (biodata_id, str, created_by, created_on, is_delete)
VALUES
    (21, 'STR-2024-0010', 1, GETDATE(), 0);



INSERT INTO t_doctor_office
    (doctor_id, medical_facilty_id, specialization, start_date, end_date, service_unit_id, created_by, created_on, is_delete)
VALUES
    (11, 41, 'spesialis paru', '2023-01-01', NULL, 1, 1, GETDATE(), 0),
    (12, 42, 'spesialis paru', '2023-01-01', NULL, 1, 1, GETDATE(), 0),
    (13, 43, 'spesialis paru', '2023-01-01', NULL, 1, 1, GETDATE(), 0),
    (14, 44, 'spesialis paru', '2023-01-01', NULL, 1, 1, GETDATE(), 0),
    (15, 45, 'spesialis paru', '2023-01-01', NULL, 1, 1, GETDATE(), 0),
    (16, 46, 'spesialis paru', '2023-01-01', NULL, 1, 1, GETDATE(), 0),
    (17, 47, 'spesialis paru', '2023-01-01', NULL, 1, 1, GETDATE(), 0),
    (18, 48, 'spesialis paru', '2023-01-01', NULL, 1, 1, GETDATE(), 0),
    (19, 49, 'spesialis paru', '2023-01-01', NULL, 1, 1, GETDATE(), 0),
    (20, 50, 'spesialis paru', '2023-01-01', NULL, 1, 1, GETDATE(), 0);

INSERT INTO t_doctor_office
    (doctor_id, medical_facilty_id, specialization, start_date, end_date, service_unit_id, created_by, created_on, is_delete)
VALUES
    (19, 3, 'spesialis paru', '2023-01-01', NULL, 1, 1, GETDATE(), 0);

INSERT INTO t_doctor_office
    (doctor_id, medical_facilty_id, specialization, start_date, end_date, service_unit_id, created_by, created_on, is_delete)
VALUES
    (21, 2, 'spesialis Anak', '2023-01-01', NULL, 1, 1, GETDATE(), 0);


INSERT INTO t_current_doctor_specialization
    (doctor_id, specialization_id, created_by, created_on, is_delete)
VALUES
    (11, 8, 1, GETDATE(), 0),
    (12, 8, 1, GETDATE(), 0),
    (13, 8, 1, GETDATE(), 0),
    (14, 8, 1, GETDATE(), 0),
    (15, 8, 1, GETDATE(), 0),
    (16, 8, 1, GETDATE(), 0),
    (17, 8, 1, GETDATE(), 0),
    (18, 8, 1, GETDATE(), 0),
    (19, 8, 1, GETDATE(), 0),
    (20, 8, 1, GETDATE(), 0);

INSERT INTO t_current_doctor_specialization
    (doctor_id, specialization_id, created_by, created_on, is_delete)
VALUES
    (21, 9, 1, GETDATE(), 0);

USE Med_341A;

SELECT *
FROM t_current_doctor_specialization

UPDATE m_biodata SET image_path='https://images.unsplash.com/photo-1582750433449-648ed127bb54?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'

SELECT *
FROM t_doctor_treatment
SELECT *
FROM t_doctor_office_treatment

TRUNCATE TABLE t_doctor_treatment;
TRUNCATE TABLE t_doctor_office_treatment;

INSERT INTO t_doctor_treatment
    (doctor_id, name, created_by, created_on, modified_by, modified_on, deleted_by, deleted_on, is_delete)
VALUES
    (1, 'Appendektomi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (1, 'Bedah Hernia', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (2, 'Pemeriksaan Penyakit Dalam', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (2, 'Kontrol Diabetes', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (3, 'Endoskopi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (3, 'Kolonoskopi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (4, 'Tes Alergi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (4, 'Imunoterapi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (5, 'Pemeriksaan Tiroid', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (5, 'Pengobatan Hormon', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (6, 'Dialisis', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (6, 'Pemeriksaan Tekanan Darah', 1, GETDATE(), Null, NULL, NULL, NULL, 0),

    (7, 'EKG', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (7, 'Ekokardiografi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (8, 'Konsultasi Andrologi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (8, 'Pemeriksaan Kesuburan', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (9, 'MRI Otak', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (9, 'EEG', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (10, 'Pemeriksaan Kulit', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (10, 'Pengobatan Jerawat', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (11, 'Pemeriksaan Paru', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (11, 'Spirometri', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (12, 'Tes Fungsi Paru', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (12, 'Pengobatan Tuberkulosis', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (13, 'Pemeriksaan Asma', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (13, 'Bronkoskopi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (14, 'Pengobatan Asma', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (14, 'Pengobatan Emfisema', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (15, 'Pemeriksaan PPOK', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (15, 'Pengobatan Pneumonia', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (16, 'Tes Alergi Paru', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (16, 'Pengobatan Bronkitis', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (17, 'Konsultasi Paru', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (17, 'Pengobatan Batuk Kronis', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (18, 'Tes Fungsi Paru', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (18, 'Pengobatan Infeksi Saluran Napas', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (19, 'Spirometri', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (19, 'Pengobatan Asma', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (20, 'Konsultasi Paru', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (20, 'Pengobatan Bronkitis', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),

    (21, 'Imunisasi', 1, GETDATE(), NULL, NULL, NULL, NULL, 0),
    (21, 'Pemeriksaan Tumbuh Kembang Anak', 1, GETDATE(), NULL, NULL, NULL, NULL, 0);


INSERT t_doctor_treatment
VALUES
    (19, 'Penanganan Tuberkulosis', 1, GETDATE(), NULL, NULL, NULL, NULL, 0);



-- ALUR NAMBAH DOKTER BARU -> M_BIODATA -> M_DOCTOR -> T_CURRENT_DOCTOR_SPECIALIZATION -> T_DOCTOR_OFFICE -> T_DOCTOR_TREATMENT -> T_DOCTOR_OFFICE_SCHEDULE
INSERT INTO m_biodata
    (fullname, mobile_phone, image, image_path, created_by, created_on, is_delete)
VALUES
    ('Dr. Fadil Ardiansyah Sp.A', '08128975632', NULL, NULL, 1, GETDATE(), 0);


INSERT INTO m_doctor
    (biodata_id, str, created_by, created_on, is_delete)
VALUES
    ((SELECT TOP 1
            id
        FROM m_biodata
        ORDER BY id DESC), 'STR-2024-0001', 1, GETDATE(), 0);


INSERT INTO t_current_doctor_specialization
    (doctor_id, specialization_id, created_by, created_on, is_delete)
VALUES
    ((SELECT TOP 1
            id
        FROM m_doctor
        ORDER BY id DESC), 8, 1, GETDATE(), 0);


INSERT INTO t_doctor_office
    (doctor_id, medical_facilty_id, specialization, start_date, end_date, service_unit_id, created_by, created_on, is_delete)
VALUES
    ((SELECT TOP 1
            id
        FROM m_doctor
        ORDER BY id DESC), 26, 'spesialis Paru', '2024-10-01', NULL, 3, 1, GETDATE(), 0);
-- ((SELECT TOP 1
--         id
--     FROM m_doctor
--     ORDER BY id DESC), 2, 'spesialis anak', '2024-10-01', NULL, 3, 1, GETDATE(), 0),
-- ((SELECT TOP 1
--         id
--     FROM m_doctor
--     ORDER BY id DESC), 38, 'spesialis anak', '2020-09-22', NULL, 3, 1, GETDATE(), 0);


INSERT t_doctor_treatment
VALUES
    ((SELECT TOP 1
            id
        FROM m_doctor
        ORDER BY id DESC), 'Penanganan Turbokulosis', 1, GETDATE(), NULL, NULL, NULL, NULL, 0);
-- ((SELECT TOP 1
--         id
--     FROM m_doctor
--     ORDER BY id DESC), 'Imunisasi Anak', 1, GETDATE(), NULL, NULL, NULL, NULL, 0);


INSERT INTO t_doctor_office_schedule
    (doctor_id, medical_facility_schedule, slot, created_by, created_on, is_delete)
VALUES
    ((SELECT TOP 1
            id
        FROM m_doctor
        ORDER BY id DESC), (SELECT TOP 1
            (medical_facilty_id * 7) - 2
        FROM t_doctor_office
        ORDER BY id DESC), 10, 1, GETDATE(), 0)
-- END TAMBAH DOCTOR


SELECT
    -- treat.id, 
    spec.[name],
    doc.id [doctor_id],
    bio.fullname
-- treat.name [treatment_name]
FROM m_doctor doc
    JOIN t_current_doctor_specialization curspec ON curspec.doctor_id = doc.id
    JOIN m_specialization spec ON spec.id = curspec.specialization_id
    JOIN m_biodata bio ON bio.id = doc.biodata_id
-- JOIN t_doctor_treatment treat ON treat.doctor_id = doc.id

SELECT df.id, spec.[name] [doctor_office_id], doc.id, bio.fullname, mf.name, df.start_date, df.end_date, df.is_delete
FROM t_doctor_office df
    JOIN m_doctor doc ON doc.id = df.doctor_id
    JOIN m_biodata bio ON bio.id = doc.biodata_id
    JOIN t_current_doctor_specialization curspec ON curspec.doctor_id = doc.id
    JOIN m_specialization spec ON spec.id = curspec.specialization_id
    JOIN m_medical_facility mf ON df.medical_facilty_id = mf.id
WHERE doc.id = 20 AND df.is_delete = 0

SELECT *
FROM t_doctor_office df
    JOIN m_doctor doc ON doc.id = df.doctor_id
    JOIN m_biodata bio ON bio.id = doc.biodata_id

UPDATE t_doctor_office SET start_date='2024-11-01' WHERE id = 20;
UPDATE t_doctor_office SET end_date='2021-01-01' WHERE id = 22;
UPDATE t_doctor_office SET is_delete=0 WHERE id = 22;



-- TAMBAH MENU ROLE
INSERT INTO m_menu
    (name, url, parent_id, big_icon, created_by, created_on, is_delete)
VALUES
    ('Doctor Settings', '', 0, 'fa fa-user-md', 1, GETDATE(), 0),
    ('Medical Feature', '', 0, 'fa fa-plus-square', 1, GETDATE(), 0),
    ('Doctor Profile', 'DokterProfil', 1, null, 1, GETDATE(), 0),
    ('Schedule Treatment', 'ScheduleTreatment', 1, null, 1, GETDATE(), 0),
    ('Settings', 'DoctorSettings', 1, null, 1, GETDATE(), 0),
    ('Search Doctor', 'FindDoctor', 2, null, 1, GETDATE(), 0),
    ('Medical', 'MedicalItem', 2, null, 1, GETDATE(), 0),
    ('Appointment', 'Appointment', 2, null, 1, GETDATE(), 0);

USE Med_341A;

TRUNCATE TABLE m_menu;
TRUNCATE TABLE m_menu_role;
TRUNCATE TABLE m_user;

INSERT INTO m_menu_role
    (menu_id, role_id, created_by, created_on, is_delete)
VALUES
    (1, 2, 1, GETDATE(), 0),
    (2, 2, 1, GETDATE(), 0),
    (3, 2, 1, GETDATE(), 0),
    (4, 2, 1, GETDATE(), 0),
    (5, 2, 1, GETDATE(), 0),
    (6, 2, 1, GETDATE(), 0),
    (7, 2, 1, GETDATE(), 0),
    (8, 2, 1, GETDATE(), 0),
    (2, 1, 1, GETDATE(), 0),
    (6, 1, 1, GETDATE(), 0),
    (7, 1, 1, GETDATE(), 0),
    (8, 1, 1, GETDATE(), 0)
-- END TAMBAH MENU ROLE


SELECT *
FROM m_role
SELECT *
FROM m_user


INSERT INTO t_doctor_office_schedule
    (doctor_id, medical_facility_schedule, slot, created_by, created_on, is_delete)
VALUES
    (1, 1, 10, 1, GETDATE(), 0),
    (1, 2, 10, 1, GETDATE(), 0),
    (1, 4, 10, 1, GETDATE(), 0),
    (2, 8, 5, 1, GETDATE(), 0),
    (2, 11, 5, 1, GETDATE(), 0),
    (2, 12, 5, 1, GETDATE(), 0),
    (3, 54, 5, 1, GETDATE(), 0),
    (3, 53, 5, 1, GETDATE(), 0),
    (3, 49, 5, 1, GETDATE(), 0),
    (4, 67, 5, 1, GETDATE(), 0),
    (4, 64, 5, 1, GETDATE(), 0),
    (4, 70, 5, 1, GETDATE(), 0),
    (5, 60, 5, 1, GETDATE(), 0),
    (5, 61, 5, 1, GETDATE(), 0),
    (5, 54, 5, 1, GETDATE(), 0),
    (6, 52, 5, 1, GETDATE(), 0),
    (6, 53, 5, 1, GETDATE(), 0),
    (6, 59, 5, 1, GETDATE(), 0),
    (7, 57, 5, 1, GETDATE(), 0),
    (7, 58, 5, 1, GETDATE(), 0),
    (8, 60, 5, 1, GETDATE(), 0),
    (8, 62, 5, 1, GETDATE(), 0),
    (9, 11, 5, 1, GETDATE(), 0),
    (9, 10, 5, 1, GETDATE(), 0),
    (10, 102, 5, 1, GETDATE(), 0),
    (10, 103, 5, 1, GETDATE(), 0),
    (11, 1, 5, 1, GETDATE(), 0),
    (11, 2, 5, 1, GETDATE(), 0),
    (12, 9, 5, 1, GETDATE(), 0),
    (12, 8, 5, 1, GETDATE(), 0),
    (13, 52, 5, 1, GETDATE(), 0),
    (13, 51, 5, 1, GETDATE(), 0),
    (14, 64, 5, 1, GETDATE(), 0),
    (14, 67, 5, 1, GETDATE(), 0),
    (15, 58, 5, 1, GETDATE(), 0),
    (15, 57, 5, 1, GETDATE(), 0),
    (16, 51, 5, 1, GETDATE(), 0),
    (16, 52, 5, 1, GETDATE(), 0),
    (17, 59, 5, 1, GETDATE(), 0),
    (17, 60, 5, 1, GETDATE(), 0),
    (18, 61, 5, 1, GETDATE(), 0),
    (18, 62, 5, 1, GETDATE(), 0),
    (19, 9, 5, 1, GETDATE(), 0),
    (19, 10, 5, 1, GETDATE(), 0),
    (20, 13, 5, 1, GETDATE(), 0),
    (20, 11, 5, 1, GETDATE(), 0);

INSERT INTO t_doctor_office_schedule
    (doctor_id, medical_facility_schedule, slot, created_by, created_on, is_delete)
VALUES
    (2, 50, 5, 1, GETDATE(), 0),
    (2, 51, 5, 1, GETDATE(), 0),
    (2, 52, 5, 1, GETDATE(), 0),
    (2, 53, 5, 1, GETDATE(), 0),
    (2, 54, 5, 1, GETDATE(), 0)


INSERT INTO t_doctor_office_schedule
    (doctor_id, medical_facility_schedule, slot, created_by, created_on, is_delete)
VALUES
    (20, 140, 5, 1, GETDATE(), 0),
    (20, 139, 5, 1, GETDATE(), 0),
    (20, 135, 5, 1, GETDATE(), 0),
    (20, 136, 5, 1, GETDATE(), 0)

INSERT INTO t_doctor_office_schedule
    (doctor_id, medical_facility_schedule, slot, created_by, created_on, is_delete)
VALUES
    (21, 12, 5, 1, GETDATE(), 0),
    (21, 10, 5, 1, GETDATE(), 0),
    (21, 9, 5, 1, GETDATE(), 0)

INSERT INTO t_doctor_office_schedule
    (doctor_id, medical_facility_schedule, slot, created_by, created_on, is_delete)
VALUES
    (1, 47, 5, 1, GETDATE(), 0),
    (1, 46, 5, 1, GETDATE(), 0),
    (1, 45, 5, 1, GETDATE(), 0),
    (3, 30, 5, 1, GETDATE(), 0),
    (3, 31, 5, 1, GETDATE(), 0),
    (3, 33, 5, 1, GETDATE(), 0),
    (4, 100, 5, 1, GETDATE(), 0),
    (4, 105, 5, 1, GETDATE(), 0),
    (4, 102, 5, 1, GETDATE(), 0),
    (5, 71, 5, 1, GETDATE(), 0),
    (5, 13, 5, 1, GETDATE(), 0),
    (5, 74, 5, 1, GETDATE(), 0),
    (6, 93, 5, 1, GETDATE(), 0),
    (6, 95, 5, 1, GETDATE(), 0),
    (6, 97, 5, 1, GETDATE(), 0),
    (7, 148, 5, 1, GETDATE(), 0),
    (7, 150, 5, 1, GETDATE(), 0),
    (7, 151, 5, 1, GETDATE(), 0),
    (8, 16, 5, 1, GETDATE(), 0),
    (8, 17, 5, 1, GETDATE(), 0),
    (8, 18, 5, 1, GETDATE(), 0),
    (9, 155, 5, 1, GETDATE(), 0),
    (9, 156, 5, 1, GETDATE(), 0),
    (10, 162, 5, 1, GETDATE(), 0),
    (10, 163, 5, 1, GETDATE(), 0),
    (10, 164, 5, 1, GETDATE(), 0),
    (11, 45, 5, 1, GETDATE(), 0),
    (11, 46, 5, 1, GETDATE(), 0),
    (11, 47, 5, 1, GETDATE(), 0),
    (12, 66, 5, 1, GETDATE(), 0),
    (12, 67, 5, 1, GETDATE(), 0),
    (12, 68, 5, 1, GETDATE(), 0),
    (13, 92, 5, 1, GETDATE(), 0),
    (13, 95, 5, 1, GETDATE(), 0),
    (13, 96, 5, 1, GETDATE(), 0),
    (14, 23, 5, 1, GETDATE(), 0),
    (14, 24, 5, 1, GETDATE(), 0),
    (14, 26, 5, 1, GETDATE(), 0),
    (15, 17, 5, 1, GETDATE(), 0),
    (15, 18, 5, 1, GETDATE(), 0),
    (15, 19, 5, 1, GETDATE(), 0),
    (16, 36, 5, 1, GETDATE(), 0),
    (16, 39, 5, 1, GETDATE(), 0),
    (16, 40, 5, 1, GETDATE(), 0),
    (17, 71, 5, 1, GETDATE(), 0),
    (17, 72, 5, 1, GETDATE(), 0),
    (17, 75, 5, 1, GETDATE(), 0),
    (18, 29, 5, 1, GETDATE(), 0),
    (18, 30, 5, 1, GETDATE(), 0),
    (18, 32, 5, 1, GETDATE(), 0),
    (19, 64, 5, 1, GETDATE(), 0),
    (19, 67, 5, 1, GETDATE(), 0),
    (19, 68, 5, 1, GETDATE(), 0),
    (18, 32, 5, 1, GETDATE(), 0),
    (21, 106, 5, 1, GETDATE(), 0),
    (21, 109, 5, 1, GETDATE(), 0),
    (21, 111, 5, 1, GETDATE(), 0),
    (24, 176, 5, 1, GETDATE(), 0),
    (24, 177, 5, 1, GETDATE(), 0),
    (24, 178, 5, 1, GETDATE(), 0),
    (24, 179, 5, 1, GETDATE(), 0);

TRUNCATE TABLE t_doctor_office_schedule

SELECT doc.id, bio.fullname, mfsh.[day], mfsh.time_schedule_start, mfsh.time_schedule_end, mf.name
FROM t_doctor_office_schedule dfsh
    JOIN m_doctor doc ON dfsh.doctor_id = doc.id
    JOIN m_biodata bio ON bio.id = doc.biodata_id
    JOIN m_medical_facility_schedule mfsh ON dfsh.medical_facility_schedule = mfsh.id
    JOIN m_medical_facility mf ON mf.id = mfsh.medical_facility_id
WHERE dfsh.is_delete = 0 AND doc.is_delete = 0 AND bio.is_delete = 0 AND mfsh.is_delete = 0


-- TAMBAH JADWAL MEDICAL FACILITY
-- Dummy data untuk m_medical_facility_schedule
INSERT INTO m_medical_facility_schedule
    (medical_facility_id, day, time_schedule_start, time_schedule_end, created_by, created_on, is_delete)
VALUES
    (1, 'Senin', '08:00', '16:00', 1, GETDATE(), 0),
    (1, 'Selasa', '08:00', '16:00', 1, GETDATE(), 0),
    (1, 'Rabu', '08:00', '16:00', 1, GETDATE(), 0),
    (1, 'Kamis', '08:00', '16:00', 1, GETDATE(), 0),
    (1, 'Jumat', '08:00', '16:00', 1, GETDATE(), 0),
    (1, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (1, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (2, 'Senin', '09:00', '17:00', 1, GETDATE(), 0),
    (2, 'Selasa', '09:00', '17:00', 1, GETDATE(), 0),
    (2, 'Rabu', '09:00', '17:00', 1, GETDATE(), 0),
    (2, 'Kamis', '09:00', '17:00', 1, GETDATE(), 0),
    (2, 'Jumat', '09:00', '17:00', 1, GETDATE(), 0),
    (2, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (2, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (3, 'Senin', '07:30', '15:30', 1, GETDATE(), 0),
    (3, 'Selasa', '07:30', '15:30', 1, GETDATE(), 0),
    (3, 'Rabu', '07:30', '15:30', 1, GETDATE(), 0),
    (3, 'Kamis', '07:30', '15:30', 1, GETDATE(), 0),
    (3, 'Jumat', '07:30', '15:30', 1, GETDATE(), 0),
    (3, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (3, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (4, 'Senin', '10:00', '18:00', 1, GETDATE(), 0),
    (4, 'Selasa', '10:00', '18:00', 1, GETDATE(), 0),
    (4, 'Rabu', '10:00', '18:00', 1, GETDATE(), 0),
    (4, 'Kamis', '10:00', '18:00', 1, GETDATE(), 0),
    (4, 'Jumat', '10:00', '18:00', 1, GETDATE(), 0),
    (4, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (4, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (5, 'Senin', '08:30', '16:30', 1, GETDATE(), 0),
    (5, 'Selasa', '08:30', '16:30', 1, GETDATE(), 0),
    (5, 'Rabu', '08:30', '16:30', 1, GETDATE(), 0),
    (5, 'Kamis', '08:30', '16:30', 1, GETDATE(), 0),
    (5, 'Jumat', '08:30', '16:30', 1, GETDATE(), 0),
    (5, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (5, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (6, 'Senin', '09:00', '17:00', 1, GETDATE(), 0),
    (6, 'Selasa', '09:00', '17:00', 1, GETDATE(), 0),
    (6, 'Rabu', '09:00', '17:00', 1, GETDATE(), 0),
    (6, 'Kamis', '09:00', '17:00', 1, GETDATE(), 0),
    (6, 'Jumat', '09:00', '17:00', 1, GETDATE(), 0),
    (6, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (6, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (7, 'Senin', '08:00', '16:00', 1, GETDATE(), 0),
    (7, 'Selasa', '08:00', '16:00', 1, GETDATE(), 0),
    (7, 'Rabu', '08:00', '16:00', 1, GETDATE(), 0),
    (7, 'Kamis', '08:00', '16:00', 1, GETDATE(), 0),
    (7, 'Jumat', '08:00', '16:00', 1, GETDATE(), 0),
    (7, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (7, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (8, 'Senin', '07:00', '15:00', 1, GETDATE(), 0),
    (8, 'Selasa', '07:00', '15:00', 1, GETDATE(), 0),
    (8, 'Rabu', '07:00', '15:00', 1, GETDATE(), 0),
    (8, 'Kamis', '07:00', '15:00', 1, GETDATE(), 0),
    (8, 'Jumat', '07:00', '15:00', 1, GETDATE(), 0),
    (8, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (8, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (9, 'Senin', '09:30', '17:30', 1, GETDATE(), 0),
    (9, 'Selasa', '09:30', '17:30', 1, GETDATE(), 0),
    (9, 'Rabu', '09:30', '17:30', 1, GETDATE(), 0),
    (9, 'Kamis', '09:30', '17:30', 1, GETDATE(), 0),
    (9, 'Jumat', '09:30', '17:30', 1, GETDATE(), 0),
    (9, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (9, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (10, 'Senin', '08:00', '14:00', 1, GETDATE(), 0),
    (10, 'Selasa', '08:00', '14:00', 1, GETDATE(), 0),
    (10, 'Rabu', '08:00', '14:00', 1, GETDATE(), 0),
    (10, 'Kamis', '08:00', '14:00', 1, GETDATE(), 0),
    (10, 'Jumat', '08:00', '14:00', 1, GETDATE(), 0),
    (10, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (10, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (11, 'Senin', '08:00', '16:00', 1, GETDATE(), 0),
    (11, 'Selasa', '08:00', '16:00', 1, GETDATE(), 0),
    (11, 'Rabu', '08:00', '16:00', 1, GETDATE(), 0),
    (11, 'Kamis', '08:00', '16:00', 1, GETDATE(), 0),
    (11, 'Jumat', '08:00', '16:00', 1, GETDATE(), 0),
    (11, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (11, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (12, 'Senin', '09:00', '17:00', 1, GETDATE(), 0),
    (12, 'Selasa', '09:00', '17:00', 1, GETDATE(), 0),
    (12, 'Rabu', '09:00', '17:00', 1, GETDATE(), 0),
    (12, 'Kamis', '09:00', '17:00', 1, GETDATE(), 0),
    (12, 'Jumat', '09:00', '17:00', 1, GETDATE(), 0),
    (12, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (12, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (13, 'Senin', '07:30', '15:30', 1, GETDATE(), 0),
    (13, 'Selasa', '07:30', '15:30', 1, GETDATE(), 0),
    (13, 'Rabu', '07:30', '15:30', 1, GETDATE(), 0),
    (13, 'Kamis', '07:30', '15:30', 1, GETDATE(), 0),
    (13, 'Jumat', '07:30', '15:30', 1, GETDATE(), 0),
    (13, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (13, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (14, 'Senin', '10:00', '18:00', 1, GETDATE(), 0),
    (14, 'Selasa', '10:00', '18:00', 1, GETDATE(), 0),
    (14, 'Rabu', '10:00', '18:00', 1, GETDATE(), 0),
    (14, 'Kamis', '10:00', '18:00', 1, GETDATE(), 0),
    (14, 'Jumat', '10:00', '18:00', 1, GETDATE(), 0),
    (14, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (14, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (15, 'Senin', '08:30', '16:30', 1, GETDATE(), 0),
    (15, 'Selasa', '08:30', '16:30', 1, GETDATE(), 0),
    (15, 'Rabu', '08:30', '16:30', 1, GETDATE(), 0),
    (15, 'Kamis', '08:30', '16:30', 1, GETDATE(), 0),
    (15, 'Jumat', '08:30', '16:30', 1, GETDATE(), 0),
    (15, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (15, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (16, 'Senin', '09:00', '17:00', 1, GETDATE(), 0),
    (16, 'Selasa', '09:00', '17:00', 1, GETDATE(), 0),
    (16, 'Rabu', '09:00', '17:00', 1, GETDATE(), 0),
    (16, 'Kamis', '09:00', '17:00', 1, GETDATE(), 0),
    (16, 'Jumat', '09:00', '17:00', 1, GETDATE(), 0),
    (16, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (16, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (17, 'Senin', '08:00', '16:00', 1, GETDATE(), 0),
    (17, 'Selasa', '08:00', '16:00', 1, GETDATE(), 0),
    (17, 'Rabu', '08:00', '16:00', 1, GETDATE(), 0),
    (17, 'Kamis', '08:00', '16:00', 1, GETDATE(), 0),
    (17, 'Jumat', '08:00', '16:00', 1, GETDATE(), 0),
    (17, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (17, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (18, 'Senin', '07:00', '15:00', 1, GETDATE(), 0),
    (18, 'Selasa', '07:00', '15:00', 1, GETDATE(), 0),
    (18, 'Rabu', '07:00', '15:00', 1, GETDATE(), 0),
    (18, 'Kamis', '07:00', '15:00', 1, GETDATE(), 0),
    (18, 'Jumat', '07:00', '15:00', 1, GETDATE(), 0),
    (18, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (18, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (19, 'Senin', '09:30', '17:30', 1, GETDATE(), 0),
    (19, 'Selasa', '09:30', '17:30', 1, GETDATE(), 0),
    (19, 'Rabu', '09:30', '17:30', 1, GETDATE(), 0),
    (19, 'Kamis', '09:30', '17:30', 1, GETDATE(), 0),
    (19, 'Jumat', '09:30', '17:30', 1, GETDATE(), 0),
    (19, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (19, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (20, 'Senin', '08:00', '14:00', 1, GETDATE(), 0),
    (20, 'Selasa', '08:00', '14:00', 1, GETDATE(), 0),
    (20, 'Rabu', '08:00', '14:00', 1, GETDATE(), 0),
    (20, 'Kamis', '08:00', '14:00', 1, GETDATE(), 0),
    (20, 'Jumat', '08:00', '14:00', 1, GETDATE(), 0),
    (20, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (20, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (21, 'Senin', '08:00', '16:00', 1, GETDATE(), 0),
    (21, 'Selasa', '08:00', '16:00', 1, GETDATE(), 0),
    (21, 'Rabu', '08:00', '16:00', 1, GETDATE(), 0),
    (21, 'Kamis', '08:00', '16:00', 1, GETDATE(), 0),
    (21, 'Jumat', '08:00', '16:00', 1, GETDATE(), 0),
    (21, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (21, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),


    (22, 'Senin', '09:00', '17:00', 1, GETDATE(), 0),
    (22, 'Selasa', '09:00', '17:00', 1, GETDATE(), 0),
    (22, 'Rabu', '09:00', '17:00', 1, GETDATE(), 0),
    (22, 'Kamis', '09:00', '17:00', 1, GETDATE(), 0),
    (22, 'Jumat', '09:00', '17:00', 1, GETDATE(), 0),
    (22, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (22, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),


    (23, 'Senin', '07:30', '15:30', 1, GETDATE(), 0),
    (23, 'Selasa', '07:30', '15:30', 1, GETDATE(), 0),
    (23, 'Rabu', '07:30', '15:30', 1, GETDATE(), 0),
    (23, 'Kamis', '07:30', '15:30', 1, GETDATE(), 0),
    (23, 'Jumat', '07:30', '15:30', 1, GETDATE(), 0),
    (23, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (23, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (24, 'Senin', '10:00', '18:00', 1, GETDATE(), 0),
    (24, 'Selasa', '10:00', '18:00', 1, GETDATE(), 0),
    (24, 'Rabu', '10:00', '18:00', 1, GETDATE(), 0),
    (24, 'Kamis', '10:00', '18:00', 1, GETDATE(), 0),
    (24, 'Jumat', '10:00', '18:00', 1, GETDATE(), 0),
    (24, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (24, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (25, 'Senin', '08:30', '16:30', 1, GETDATE(), 0),
    (25, 'Selasa', '08:30', '16:30', 1, GETDATE(), 0),
    (25, 'Rabu', '08:30', '16:30', 1, GETDATE(), 0),
    (25, 'Kamis', '08:30', '16:30', 1, GETDATE(), 0),
    (25, 'Jumat', '08:30', '16:30', 1, GETDATE(), 0),
    (25, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (25, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (26, 'Senin', '09:00', '17:00', 1, GETDATE(), 0),
    (26, 'Selasa', '09:00', '17:00', 1, GETDATE(), 0),
    (26, 'Rabu', '09:00', '17:00', 1, GETDATE(), 0),
    (26, 'Kamis', '09:00', '17:00', 1, GETDATE(), 0),
    (26, 'Jumat', '09:00', '17:00', 1, GETDATE(), 0),
    (26, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (26, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (27, 'Senin', '08:00', '16:00', 1, GETDATE(), 0),
    (27, 'Selasa', '08:00', '16:00', 1, GETDATE(), 0),
    (27, 'Rabu', '08:00', '16:00', 1, GETDATE(), 0),
    (27, 'Kamis', '08:00', '16:00', 1, GETDATE(), 0),
    (27, 'Jumat', '08:00', '16:00', 1, GETDATE(), 0),
    (27, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (27, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (28, 'Senin', '07:00', '15:00', 1, GETDATE(), 0),
    (28, 'Selasa', '07:00', '15:00', 1, GETDATE(), 0),
    (28, 'Rabu', '07:00', '15:00', 1, GETDATE(), 0),
    (28, 'Kamis', '07:00', '15:00', 1, GETDATE(), 0),
    (28, 'Jumat', '07:00', '15:00', 1, GETDATE(), 0),
    (28, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (28, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (29, 'Senin', '09:30', '17:30', 1, GETDATE(), 0),
    (29, 'Selasa', '09:30', '17:30', 1, GETDATE(), 0),
    (29, 'Rabu', '09:30', '17:30', 1, GETDATE(), 0),
    (29, 'Kamis', '09:30', '17:30', 1, GETDATE(), 0),
    (29, 'Jumat', '09:30', '17:30', 1, GETDATE(), 0),
    (29, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (29, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (30, 'Senin', '08:00', '14:00', 1, GETDATE(), 0),
    (30, 'Selasa', '08:00', '14:00', 1, GETDATE(), 0),
    (30, 'Rabu', '08:00', '14:00', 1, GETDATE(), 0),
    (30, 'Kamis', '08:00', '14:00', 1, GETDATE(), 0),
    (30, 'Jumat', '08:00', '14:00', 1, GETDATE(), 0),
    (30, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (30, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),


    (31, 'Senin', '08:00', '16:00', 1, GETDATE(), 0),
    (31, 'Selasa', '08:00', '16:00', 1, GETDATE(), 0),
    (31, 'Rabu', '08:00', '16:00', 1, GETDATE(), 0),
    (31, 'Kamis', '08:00', '16:00', 1, GETDATE(), 0),
    (31, 'Jumat', '08:00', '16:00', 1, GETDATE(), 0),
    (31, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (31, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),


    (32, 'Senin', '09:00', '17:00', 1, GETDATE(), 0),
    (32, 'Selasa', '09:00', '17:00', 1, GETDATE(), 0),
    (32, 'Rabu', '09:00', '17:00', 1, GETDATE(), 0),
    (32, 'Kamis', '09:00', '17:00', 1, GETDATE(), 0),
    (32, 'Jumat', '09:00', '17:00', 1, GETDATE(), 0),
    (32, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (32, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),


    (33, 'Senin', '07:30', '15:30', 1, GETDATE(), 0),
    (33, 'Selasa', '07:30', '15:30', 1, GETDATE(), 0),
    (33, 'Rabu', '07:30', '15:30', 1, GETDATE(), 0),
    (33, 'Kamis', '07:30', '15:30', 1, GETDATE(), 0),
    (33, 'Jumat', '07:30', '15:30', 1, GETDATE(), 0),
    (33, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (33, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (34, 'Senin', '10:00', '18:00', 1, GETDATE(), 0),
    (34, 'Selasa', '10:00', '18:00', 1, GETDATE(), 0),
    (34, 'Rabu', '10:00', '18:00', 1, GETDATE(), 0),
    (34, 'Kamis', '10:00', '18:00', 1, GETDATE(), 0),
    (34, 'Jumat', '10:00', '18:00', 1, GETDATE(), 0),
    (34, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (34, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (35, 'Senin', '08:30', '16:30', 1, GETDATE(), 0),
    (35, 'Selasa', '08:30', '16:30', 1, GETDATE(), 0),
    (35, 'Rabu', '08:30', '16:30', 1, GETDATE(), 0),
    (35, 'Kamis', '08:30', '16:30', 1, GETDATE(), 0),
    (35, 'Jumat', '08:30', '16:30', 1, GETDATE(), 0),
    (35, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (35, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (36, 'Senin', '09:00', '17:00', 1, GETDATE(), 0),
    (36, 'Selasa', '09:00', '17:00', 1, GETDATE(), 0),
    (36, 'Rabu', '09:00', '17:00', 1, GETDATE(), 0),
    (36, 'Kamis', '09:00', '17:00', 1, GETDATE(), 0),
    (36, 'Jumat', '09:00', '17:00', 1, GETDATE(), 0),
    (36, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (36, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (37, 'Senin', '08:00', '16:00', 1, GETDATE(), 0),
    (37, 'Selasa', '08:00', '16:00', 1, GETDATE(), 0),
    (37, 'Rabu', '08:00', '16:00', 1, GETDATE(), 0),
    (37, 'Kamis', '08:00', '16:00', 1, GETDATE(), 0),
    (37, 'Jumat', '08:00', '16:00', 1, GETDATE(), 0),
    (37, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (37, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (38, 'Senin', '07:00', '15:00', 1, GETDATE(), 0),
    (38, 'Selasa', '07:00', '15:00', 1, GETDATE(), 0),
    (38, 'Rabu', '07:00', '15:00', 1, GETDATE(), 0),
    (38, 'Kamis', '07:00', '15:00', 1, GETDATE(), 0),
    (38, 'Jumat', '07:00', '15:00', 1, GETDATE(), 0),
    (38, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (38, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (39, 'Senin', '09:30', '17:30', 1, GETDATE(), 0),
    (39, 'Selasa', '09:30', '17:30', 1, GETDATE(), 0),
    (39, 'Rabu', '09:30', '17:30', 1, GETDATE(), 0),
    (39, 'Kamis', '09:30', '17:30', 1, GETDATE(), 0),
    (39, 'Jumat', '09:30', '17:30', 1, GETDATE(), 0),
    (39, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (39, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (40, 'Senin', '08:00', '14:00', 1, GETDATE(), 0),
    (40, 'Selasa', '08:00', '14:00', 1, GETDATE(), 0),
    (40, 'Rabu', '08:00', '14:00', 1, GETDATE(), 0),
    (40, 'Kamis', '08:00', '14:00', 1, GETDATE(), 0),
    (40, 'Jumat', '08:00', '14:00', 1, GETDATE(), 0),
    (40, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (40, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (41, 'Senin', '08:00', '16:00', 1, GETDATE(), 0),
    (41, 'Selasa', '08:00', '16:00', 1, GETDATE(), 0),
    (41, 'Rabu', '08:00', '16:00', 1, GETDATE(), 0),
    (41, 'Kamis', '08:00', '16:00', 1, GETDATE(), 0),
    (41, 'Jumat', '08:00', '16:00', 1, GETDATE(), 0),
    (41, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (41, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (42, 'Senin', '09:00', '17:00', 1, GETDATE(), 0),
    (42, 'Selasa', '09:00', '17:00', 1, GETDATE(), 0),
    (42, 'Rabu', '09:00', '17:00', 1, GETDATE(), 0),
    (42, 'Kamis', '09:00', '17:00', 1, GETDATE(), 0),
    (42, 'Jumat', '09:00', '17:00', 1, GETDATE(), 0),
    (42, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (42, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (43, 'Senin', '07:30', '15:30', 1, GETDATE(), 0),
    (43, 'Selasa', '07:30', '15:30', 1, GETDATE(), 0),
    (43, 'Rabu', '07:30', '15:30', 1, GETDATE(), 0),
    (43, 'Kamis', '07:30', '15:30', 1, GETDATE(), 0),
    (43, 'Jumat', '07:30', '15:30', 1, GETDATE(), 0),
    (43, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (43, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (44, 'Senin', '10:00', '18:00', 1, GETDATE(), 0),
    (44, 'Selasa', '10:00', '18:00', 1, GETDATE(), 0),
    (44, 'Rabu', '10:00', '18:00', 1, GETDATE(), 0),
    (44, 'Kamis', '10:00', '18:00', 1, GETDATE(), 0),
    (44, 'Jumat', '10:00', '18:00', 1, GETDATE(), 0),
    (44, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (44, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (45, 'Senin', '08:30', '16:30', 1, GETDATE(), 0),
    (45, 'Selasa', '08:30', '16:30', 1, GETDATE(), 0),
    (45, 'Rabu', '08:30', '16:30', 1, GETDATE(), 0),
    (45, 'Kamis', '08:30', '16:30', 1, GETDATE(), 0),
    (45, 'Jumat', '08:30', '16:30', 1, GETDATE(), 0),
    (45, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (45, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (46, 'Senin', '09:00', '17:00', 1, GETDATE(), 0),
    (46, 'Selasa', '09:00', '17:00', 1, GETDATE(), 0),
    (46, 'Rabu', '09:00', '17:00', 1, GETDATE(), 0),
    (46, 'Kamis', '09:00', '17:00', 1, GETDATE(), 0),
    (46, 'Jumat', '09:00', '17:00', 1, GETDATE(), 0),
    (46, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (46, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (47, 'Senin', '08:00', '16:00', 1, GETDATE(), 0),
    (47, 'Selasa', '08:00', '16:00', 1, GETDATE(), 0),
    (47, 'Rabu', '08:00', '16:00', 1, GETDATE(), 0),
    (47, 'Kamis', '08:00', '16:00', 1, GETDATE(), 0),
    (47, 'Jumat', '08:00', '16:00', 1, GETDATE(), 0),
    (47, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (47, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (48, 'Senin', '07:00', '15:00', 1, GETDATE(), 0),
    (48, 'Selasa', '07:00', '15:00', 1, GETDATE(), 0),
    (48, 'Rabu', '07:00', '15:00', 1, GETDATE(), 0),
    (48, 'Kamis', '07:00', '15:00', 1, GETDATE(), 0),
    (48, 'Jumat', '07:00', '15:00', 1, GETDATE(), 0),
    (48, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (48, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),


    (49, 'Senin', '10:00', '18:00', 1, GETDATE(), 0),
    (49, 'Selasa', '10:00', '18:00', 1, GETDATE(), 0),
    (49, 'Rabu', '10:00', '18:00', 1, GETDATE(), 0),
    (49, 'Kamis', '10:00', '18:00', 1, GETDATE(), 0),
    (49, 'Jumat', '10:00', '18:00', 1, GETDATE(), 0),
    (49, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (49, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0),

    (50, 'Senin', '08:30', '16:30', 1, GETDATE(), 0),
    (50, 'Selasa', '08:30', '16:30', 1, GETDATE(), 0),
    (50, 'Rabu', '08:30', '16:30', 1, GETDATE(), 0),
    (50, 'Kamis', '08:30', '16:30', 1, GETDATE(), 0),
    (50, 'Jumat', '08:30', '16:30', 1, GETDATE(), 0),
    (50, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (50, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0);


INSERT INTO m_medical_facility_schedule
    (medical_facility_id, day, time_schedule_start, time_schedule_end, created_by, created_on, is_delete)
VALUES
    (26, 'Senin', '08:00', '16:00', 1, GETDATE(), 0),
    (26, 'Selasa', '08:00', '16:00', 1, GETDATE(), 0),
    (26, 'Rabu', '08:00', '16:00', 1, GETDATE(), 0),
    (26, 'Kamis', '08:00', '16:00', 1, GETDATE(), 0),
    (26, 'Jumat', '08:00', '16:00', 1, GETDATE(), 0),
    (26, 'Sabtu', '08:00', '16:00', 1, GETDATE(), 0),
    (26, 'Minggu', '08:00', '16:00', 1, GETDATE(), 0);

INSERT INTO t_doctor_office_schedule
    (medical_facility_schedule, slot, doctor_id, created_by, created_on, is_delete)
VALUES
    (1051, 10, 24, 24, GETDATE(), 0),
    (1054, 10, 24, 24, GETDATE(), 0);

TRUNCATE TABLE m_medical_facility_schedule



---- 

SELECT *
FROM m_medical_facility_schedule
WHERE medical_facility_id=26

-- COBA-COBA DULU YA

SELECT *
FROM m_menu;
SELECT *
FROM m_menu_role;
SELECT *
FROM m_role;
SELECT *
FROM m_user;
SELECT *
FROM t_token

INSERT INTO m_menu
    (name, url, parent_id, big_icon, created_by, created_on, is_delete)
VALUES
    ('Doctor Settings', '', 0, 'fa fa-user-md', 1, GETDATE(), 0),
    ('Medical Feature', '', 0, 'fa fa-plus-square', 1, GETDATE(), 0),
    ('Doctor Profile', 'DokterProfil', 1, null, 1, GETDATE(), 0),
    ('Schedule Treatment', 'ScheduleTreatment', 1, null, 1, GETDATE(), 0),
    ('Settings', 'DoctorSettings', 1, null, 1, GETDATE(), 0),
    ('Search Doctor', 'FindDoctor', 2, null, 1, GETDATE(), 0),
    ('Medical', 'MedicalItem', 2, null, 1, GETDATE(), 0),
    ('Appointment', 'Appointment', 2, null, 1, GETDATE(), 0);

INSERT INTO m_role
    (name, code, created_by, created_on, is_delete)
VALUES
    ('public', '1414', 1, GETDATE(), 0)

SELECT *
FROM m_role;

INSERT INTO m_menu_role
    (menu_id, role_id, created_by, created_on, is_delete)
VALUES
    (1, 2, 1, GETDATE(), 0),
    (2, 2, 1, GETDATE(), 0),
    (3, 2, 1, GETDATE(), 0),
    (4, 2, 1, GETDATE(), 0),
    (5, 2, 1, GETDATE(), 0),
    (6, 2, 1, GETDATE(), 0),
    (7, 2, 1, GETDATE(), 0),
    (8, 2, 1, GETDATE(), 0),
    (2, 1, 1, GETDATE(), 0),
    (6, 1, 1, GETDATE(), 0),
    (7, 1, 1, GETDATE(), 0),
    (8, 1, 1, GETDATE(), 0)
-- END TAMBAH MENU ROLE

SELECT *
FROM m_role;

SELECT *
FROM m_user;

SELECT *
FROM m_menu;

SELECT *
FROM m_menu_role

INSERT INTO m_role
    (name, code,created_by, created_on, is_delete)
VALUES
    ('pasien', '111111', 1, GETDATE(), 0),
    ('dokter', '222222', 1, GETDATE(), 0),
    ('public', '333333', 1, GETDATE(), 0);

TRUNCATE TABLE m_menu;
TRUNCATE TABLE m_menu_role;
TRUNCATE TABLE m_user;
TRUNCATE TABLE m_role;
TRUNCATE TABLE t_token;

INSERT INTO m_menu
    (name, url, parent_id, big_icon, small_icon, created_by, created_on, modified_by, modified_on, deleted_by, deleted_on, is_delete)
VALUES
    -- 1
    ('Master', '', 0, 'fas fa-solid fa-brain', 'fas fa-regular fa-brain', 1, GETDATE(), null, null, null, null, 0),
    -- 2
    ('Transaction', '', 0, 'fas fa-solid fa-anchor', 'fas fa-regular fa-anchor', 1, GETDATE(), null, null, null, null, 0),
    -- 3
    ('Logout', 'Auth/Logout', 0, 'fas fa-sign-out-alt', 'fas fa-regular fa-anchor', 1, GETDATE(), null, null, null, null, 0),

    -- 4
    ('Role', 'Role/Index', 1, '', '', 1, GETDATE(), null, null, null, null, 0),
    --5
    ('Hak Askes Menu', 'MenuRole/Index', 1, '', '', 1, GETDATE(), null, null, null, null, 0),
    --6
    ('Profil Dokter', 'DokterProfil/Index', 1, '', '', 1, GETDATE(), null, null, null, null, 0),
    --7
    ('Profil Pasien', 'UserProfil/Index', 1, '', '', 1, GETDATE(), null, null, null, null, 0),

    --8
    ('Cari Obat', 'MedicalItem/Index', 2, '', '', 1, GETDATE(), null, null, null, null, 0),
    --9
    ('Cari Dokter', 'FindDoctor/Index', 2, '', '', 1, GETDATE(), null, null, null, null, 0);


SELECT mr.id [menu_role_id], m.id [m_menu_id] , m.name [menu_name], r.name, mr.is_delete
FROM m_menu_role mr
    JOIN m_role r ON mr.role_id = r.id
    JOIN m_menu m ON m.id = mr.menu_id

SELECT *
FROM m_menu_role

SELECT *
FROM m_menu;

SELECT *
FROM
    m_role;

SELECT *
FROM t_token
ORDER BY id DESC;

SELECT *
FROM m_user

UPDATE m_user SET is_locked=0, login_attempt=4 WHERE id=1;

UPDATE m_user SET is_locked=0, login_attempt=0 WHERE email='fadilansyah25.dev@gmail.com';

UPDATE m_menu_role SET is_delete = 1 WHERE id IN (20);

INSERT INTO m_menu_role
    (menu_id, role_id, created_by, created_on, is_delete)
VALUES
    (7, 4, 4, GETDATE(), 0)

--- SCHEDULE DOCTOR
SELECT
    doc.id,
    bio.fullname,
    mfs.medical_facility_id,
    mf.name [medical facility name],
    mfc.name [medical facility category],
    mfs.[day], mfs.time_schedule_start,
    mfs.time_schedule_end,
    df.start_date,
    df.end_date
FROM t_doctor_office_schedule dos
    JOIN m_medical_facility_schedule mfs ON mfs.id = dos.medical_facility_schedule
    JOIN m_doctor doc ON doc.id = dos.doctor_id
    JOIN m_biodata bio ON bio.id = doc.biodata_id
    JOIN m_medical_facility mf ON mfs.medical_facility_id = mf.id
    JOIN m_medical_facility_category mfc ON mfc.id = mf.medical_facility_category_id
    JOIN t_doctor_office df ON df.doctor_id = doc.biodata_id AND df.medical_facilty_id = mf.id
-- WHERE doc.id = 24
-- AND df.end_date IS NULL

SELECT *
FROM m_medical_facility
SELECT *
FROM t_doctor_office
SELECT *
FROM m_doctor

SELECT *
FROM m_medical_facility  mf
    JOIN m_medical_facility_category mfc ON mfc.id =  mf.medical_facility_category_id

SELECT bio.fullname, mf.name, mfc.name, mfsh.[day], mfsh.time_schedule_start, mfsh.time_schedule_end, mfsh.id
FROM
    -- FROM t_doctor_office_schedule dof
    t_doctor_office docOffice
    JOIN m_doctor doc ON docOffice.doctor_id = doc.id
    JOIN m_biodata bio ON bio.id = doc.biodata_id
    JOIN m_medical_facility mf ON mf.id = docOffice.medical_facilty_id
    JOIN m_medical_facility_category mfc ON mfc.id = mf.medical_facility_category_id
    JOIN t_doctor_office_schedule dos ON dos.doctor_id = doc.id
    JOIN m_medical_facility_schedule mfsh ON dos.medical_facility_schedule = mfsh.id
WHERE docOffice.doctor_id = 24
ORDER BY mfsh.[day]

UPDATE m_medical_facility_schedule SET time_schedule_end='12:00' WHERE id=179
UPDATE m_medical_facility_schedule SET [day] = 'Kamis',time_schedule_start='18:00', time_schedule_end='22:00' WHERE id=178

INSERT INTO t_doctor_office_schedule
    (doctor_id, medical_facility_schedule, slot, created_by, created_on, is_delete)
VALUES
    (24, 176, 10, 1, GETDATE(), 0)

-- DOCTOR OFFICE 
SELECT
    df.id, spec.[name] 'specialization',
    doc.id 'doctor_id',
    bio.fullname,
    mf.id [medical_facility_id],
    mf.name [mf_name],
    df.start_date,
    df.end_date,
    df.is_delete
FROM t_doctor_office df
    JOIN m_doctor doc ON doc.id = df.doctor_id
    JOIN m_biodata bio ON bio.id = doc.biodata_id
    JOIN t_current_doctor_specialization curspec ON curspec.doctor_id = doc.id
    JOIN m_specialization spec ON spec.id = curspec.specialization_id
    JOIN m_medical_facility mf ON df.medical_facilty_id = mf.id
WHERE doc.id = 20

-- INSERT INTO t_doctor_office_schedule(doctor_id, medical_facility_schedule, created_by, created_on, is_delete)
-- VALUES

SELECT *
FROM m_doctor doc
    JOIN m_biodata mb ON doc.biodata_id= mb.id
WHERE doc.id = 24;

SELECT *
from m_medical_facility_schedule;

UPDATE t_doctor_office SET end_date='2022-01-07' WHERE id=20 AND doctor_id=20
UPDATE t_doctor_office SET start_date='2021-11-15' WHERE id=20 AND doctor_id=20
UPDATE t_doctor_office SET is_delete=0 WHERE id=20 AND doctor_id=20
UPDATE t_doctor_office SET start_date='2024-01-01' WHERE id=22 AND doctor_id=20
UPDATE t_doctor_office SET end_date=null WHERE id=22 AND doctor_id=20
UPDATE t_doctor_office SET is_delete=0 WHERE id=22 AND doctor_id=20
DELETE t_doctor_office WHERE doctor_id=2 AND medical_facilty_id=13


SELECT m.name
FROM m_menu_role mr
    LEFT JOIN
    (
        SELECT child.id, child.name, child.parent_id
    FROM m_menu parent
        INNER JOIN m_menu child
        ON child.parent_id = parent.id
    )
    as m
    ON m.id = mr.menu_id
WHERE mr.role_id=4 AND mr.is_delete=0
ORDER BY m.parent_id

SELECT *
FROM m_medical_facility_category

INSERT INTO m_medical_facility_category
    (name, created_by, created_on, is_delete)
VALUES
    ('Rumah sakit Online', 1, GETDATE(), 0)


UPDATE m_medical_facility_category SET name='Online' WHERE id=1
UPDATE m_medical_facility_category SET name='Offline' WHERE id=2
DELETE m_medical_facility_category WHERE id=3

TRUNCATE TABLE m_medical_facility_category;

SELECT *
FROM m_menu;

SELECT *
FROM m_menu_role

INSERT INTO m_menu_role
    (menu_id, role_id, created_by, created_on, is_delete)
VALUES
    (6, 4, 1, GETDATE(), 0)