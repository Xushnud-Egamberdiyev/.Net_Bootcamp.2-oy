using System.Collections.Generic;

//CREATE TABLE Animals(
//	PetId BIGSERIAL PRIMARY KEY,
//    Name varchar(100) NOT NULL,
//    Age int NOT NULL,
//    Breed Varchar(100) NOT NULL,
//    Adaption Varchar(100) NOT NULL
//);

//CREATE TABLE PotentialAdopters(
//	AdopterId BIGSERIAL PRIMARY KEY,
//    Name varchar(100) NOT NULL,
//    ContactInformation varchar(100) NOT NULL,
//    Home_envi varchar(100) NOT NULL
//);

//CREATE TABLE AdoptionTransactions(
//	TransactionID BIGSERIAL PRIMARY KEY,
//    DateOfAdoption DATE,
//    PetId int,
//    AdopterId int,
//    TransactionStatus VARCHAR(20),

//    FOREIGN KEY(PetId) REFERENCES Animals(PetId),
//    FOREIGN KEY(AdopterId) REFERENCES PotentialAdopters(AdopterId)
//);

//CREATE TABLE MedicalRecords (
//    MedicalRecordID SERIAL PRIMARY KEY,
//    PetID INT,
//    VaccinationStatus VARCHAR(50),
//    LastVetVisitDate DATE,
//    MedicalConditions VARCHAR(200),
//    FOREIGN KEY (PetID) REFERENCES Animals(PetID)
//);

//insert into Animals (PetId, Name, Age, Breed, Adaption) values (1, 'Masked booby', 3, 'M', 'EST');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (2, 'Red-billed buffalo weaver', 6, 'M', 'UNU');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (3, 'Bird, magnificent frigate', 16, 'M', 'YOY');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (4, 'Shelduck, european', 14, 'M', 'CLO');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (5, 'Gray rhea', 18, 'M', 'CKW');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (6, 'Common green iguana', 16, 'M', 'RHT');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (7, 'Magpie, australian', 7, 'M', 'PYA');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (8, 'Zorro, common', 18, 'F', 'AKW');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (9, 'Raccoon, common', 11, 'F', 'QGQ');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (10, 'Cormorant, little', 1, 'F', 'FDK');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (11, 'Black-necked stork', 4, 'M', 'PLU');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (12, 'Western palm tanager (unidentified)', 13, 'M', 'FWL');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (13, 'Red-tailed cockatoo', 15, 'F', 'IMK');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (14, 'Beisa oryx', 18, 'M', 'CLL');
//insert into Animals (PetId, Name, Age, Breed, Adaption) values (15, 'Smith''s bush squirrel', 19, 'F', 'PEG');

//SELECT* FROM Animals
	
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (1, 'Shaun', 'NA', 'SA');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (2, 'Jerrilyn', 'NA', 'NA');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (3, 'Urbanus', 'OC', 'AS');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (4, 'Kevyn', 'NA', 'NA');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (5, 'Ginnifer', 'OC', 'OC');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (6, 'Jobyna', 'SA', 'NA');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (7, 'Mateo', 'EU', 'AS');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (8, 'Marketa', 'AS', 'NA');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (9, 'Job', 'AF', 'NA');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (10, 'Chantalle', 'NA', 'NA');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (11, 'Kirsten', 'AS', 'AS');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (12, 'Lexie', 'OC', 'EU');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (13, 'Zach', 'OC', 'AF');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (14, 'Emera', 'SA', 'AS');
//insert into PotentialAdopters (AdopterId, Name, ContactInformation, Home_envi) values (15, 'Madelina', 'NA', 'OC');

//CREATE OR REPLACE procedure avg_age_by_breed1(breed1 VARCHAR)
//LANGUAGE plpgsql
//as $$
//BEGIN
//    raise notice select AVG(Age) FROM Animals WHERE Breed = breed1;

//END
//$$;

//create or replace procedure pets_count_of_adopter(adopter_id int)
//language plpgsql
//AS $$
//BEGIN
//  raise notice select count(*) from Aboption_Transactions where where adopter = adopter_id;
//END
//$$;


//CREATE OR REPLACE FUNCTION generate_medical_records_of_pet(petId INT)
//RETURNS TABLE (
//    MedicalRecordID INT,
//    PetID INT,
//    VaccinationStatus VARCHAR(50),
//    LastVetVisitDate DATE,
//    MedicalConditions VARCHAR(200)
//) 
//LANGUAGE plpgsql
//AS $$
//BEGIN
//    RETURN QUERY SELECT * FROM MedicalRecords WHERE PetID = petId;
//END;
//$$;