using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

//CREATE TABLE "student_access"(
//    "student_id" BIGINT NOT NULL,
//    "subject_id" BIGINT NOT NULL
//);
//ALTER TABLE
//    "student_access" ADD PRIMARY KEY("student_id","subject");


//CREATE TABLE "student"(
//    "id" bigserial NOT NULL,
//    "first_name" VARCHAR(255) NOT NULL,
//    "last_name" VARCHAR(255) NOT NULL,
//    "age" INTEGER NOT NULL,
//    "group_id" BIGINT NOT NULL
//);
//ALTER TABLE
//    "student" ADD PRIMARY KEY("id");


//CREATE TABLE "student_of_group"(
//    "id" bigserial NOT NULL,
//    "name" VARCHAR(255) NOT NULL,
//    "count" INTEGER NOT NULL
//);
//ALTER TABLE
//    "student_of_group" ADD PRIMARY KEY("id");


//CREATE TABLE "subject"(
//    "id" bigserial NOT NULL,
//    "name" VARCHAR(255) NOT NULL
//);
//ALTER TABLE
//    "subject" ADD PRIMARY KEY("id");


//ALTER TABLE
//    "student_access" ADD CONSTRAINT "student_access_subject_id_foreign" FOREIGN KEY("subject_id") REFERENCES "subject"("id");
//ALTER TABLE
//    "student_access" ADD CONSTRAINT "student_access_student_id_foreign" FOREIGN KEY("student_id") REFERENCES "student"("id");
//ALTER TABLE
//    "student" ADD CONSTRAINT "student_group_id_foreign" FOREIGN KEY("group_id") REFERENCES "student_of_group"("id");

//insert into student (first_name, last_name, age, group_id) values ('Sileas', 'Phillps', 86, 5);
//insert into student (first_name, last_name, age, group_id) values ('Stephan', 'Kenlin', 59, 15);
//insert into student (first_name, last_name, age, group_id) values ('Berry', 'Freeman', 14, 15);
//insert into student (first_name, last_name, age, group_id) values ('Carleton', 'ducarme', 12, 11);
//insert into student (first_name, last_name, age, group_id) values ('Allie', 'Wyss', 30, 9);
//insert into student (first_name, last_name, age, group_id) values ('Sigismond', 'Workman', 67, 15);
//insert into student (first_name, last_name, age, group_id) values ('Nikolos', 'Roostan', 80, 7);
//insert into student (first_name, last_name, age, group_id) values ('Wilburt', 'Cluet', 14, 11);
//insert into student (first_name, last_name, age, group_id) values ('Zeb', 'Drillingcourt', 71, 16);
//insert into student (first_name, last_name, age, group_id) values ('Sandye', 'Bateman', 37, 8);
//insert into student (first_name, last_name, age, group_id) values ('Tandie', 'Worssam', 41, 13);
//insert into student (first_name, last_name, age, group_id) values ('Saba', 'Bassick', 73, 2);
//insert into student (first_name, last_name, age, group_id) values ('Rennie', 'Davidow', 49, 2);
//insert into student (first_name, last_name, age, group_id) values ('Charita', 'Kidman', 39, 12);
//insert into student (first_name, last_name, age, group_id) values ('Chris', 'Daddow', 25, 1);
//insert into student (first_name, last_name, age, group_id) values ('Gracia', 'Chamberlaine', 68, 13);
//insert into student (first_name, last_name, age, group_id) values ('Marlena', 'Kemm', 59, 7);
//insert into student (first_name, last_name, age, group_id) values ('Marabel', 'Vauter', 25, 8);
//insert into student (first_name, last_name, age, group_id) values ('Inesita', 'Morsey', 12, 5);
//insert into student (first_name, last_name, age, group_id) values ('Renault', 'Medhurst', 26, 1);
//insert into student (first_name, last_name, age, group_id) values ('Marlin', 'Gilleson', 87, 14);
//insert into student (first_name, last_name, age, group_id) values ('Chick', 'Casella', 85, 15);
//insert into student (first_name, last_name, age, group_id) values ('Niles', 'Bastable', 91, 7);
//insert into student (first_name, last_name, age, group_id) values ('Manfred', 'Snowsill', 65, 6);
//insert into student (first_name, last_name, age, group_id) values ('Corrinne', 'Rambaut', 24, 10);
//insert into student (first_name, last_name, age, group_id) values ('Meriel', 'Weatherhogg', 2, 8);
//insert into student (first_name, last_name, age, group_id) values ('Vittorio', 'Broggelli', 77, 5);
//insert into student (first_name, last_name, age, group_id) values ('Germain', 'Dionsetti', 83, 6);
//insert into student (first_name, last_name, age, group_id) values ('Avery', 'Dabinett', 82, 14);
//insert into student (first_name, last_name, age, group_id) values ('Randy', 'Stapleton', 68, 8);
//insert into student (first_name, last_name, age, group_id) values ('Vic', 'Baudesson', 54, 14);
//insert into student (first_name, last_name, age, group_id) values ('Virginia', 'Reddoch', 54, 8);
//insert into student (first_name, last_name, age, group_id) values ('Andrei', 'Pragnall', 20, 15);
//insert into student (first_name, last_name, age, group_id) values ('Hanna', 'Ilem', 49, 14);
//insert into student (first_name, last_name, age, group_id) values ('Elyse', 'Sinott', 89, 11);
//insert into student (first_name, last_name, age, group_id) values ('Lenard', 'Boshere', 41, 4);
//insert into student (first_name, last_name, age, group_id) values ('Reynold', 'Brise', 78, 8);
//insert into student (first_name, last_name, age, group_id) values ('Auria', 'Zanuciolii', 24, 1);
//insert into student (first_name, last_name, age, group_id) values ('Teodoor', 'Yanuk', 25, 4);
//insert into student (first_name, last_name, age, group_id) values ('Waldo', 'Follacaro', 41, 13);
//insert into student (first_name, last_name, age, group_id) values ('Adham', 'O''Brollachain', 82, 11);
//insert into student (first_name, last_name, age, group_id) values ('Blanch', 'Duffield', 43, 9);
//insert into student (first_name, last_name, age, group_id) values ('Waldemar', 'Bumpus', 12, 4);
//insert into student (first_name, last_name, age, group_id) values ('Micki', 'Rebanks', 49, 11);
//insert into student (first_name, last_name, age, group_id) values ('Paolina', 'Sillwood', 67, 3);
//insert into student (first_name, last_name, age, group_id) values ('Edmon', 'Gorse', 16, 14);
//insert into student (first_name, last_name, age, group_id) values ('Nikolaos', 'Faill', 41, 1);
//insert into student (first_name, last_name, age, group_id) values ('Melony', 'Axtell', 38, 17);
//insert into student (first_name, last_name, age, group_id) values ('Neil', 'Sherrell', 32, 11);
//insert into student (first_name, last_name, age, group_id) values ('Dorice', 'Czajkowska', 46, 8);

//insert into student_of_group (name, count) values ('University of Montana Western', 5);
//insert into student_of_group (name, count) values ('St. Francis College, Loretto', 33);
//insert into student_of_group (name, count) values ('Targu-Mures University of Theatre', 6);
//insert into student_of_group (name, count) values ('Durban Institute of Technology', 20);
//insert into student_of_group (name, count) values ('University of California, San Diego', 22);
//insert into student_of_group (name, count) values ('University of Silesia', 13);
//insert into student_of_group (name, count) values ('Zimbabwe Open University', 36);
//insert into student_of_group (name, count) values ('Carleton University', 16);
//insert into student_of_group (name, count) values ('Singapore Institute of Management (SIM)', 23);
//insert into student_of_group (name, count) values ('South Gujarat University', 7);
//insert into student_of_group (name, count) values ('Savannah College of Art and Design', 49);
//insert into student_of_group (name, count) values ('Beijing Institute of Technology', 17);
//insert into student_of_group (name, count) values ('Fachhochschule für Verwaltung und Rechtspflege Berlin', 36);
//insert into student_of_group (name, count) values ('Bethune-Cookman College', 30);
//insert into student_of_group (name, count) values ('Université de Metz', 32);
//insert into student_of_group (name, count) values ('Dagestan State University', 2);
//insert into student_of_group (name, count) values ('Ecole Européenne de Chimie, Polymères et Matériaux de Strasbourg', 4);
//insert into student_of_group (name, count) values ('St. Luke''s College', 3);
//insert into student_of_group (name, count) values ('University of Aizu', 23);
//insert into student_of_group (name, count) values ('Lees-McRae College', 42);



//insert into subject (name) values ('Dwarf Hesperochiron');
//insert into subject (name) values ('Fineleaf Hymenopappus');
//insert into subject (name) values ('Pitcherplant');
//insert into subject (name) values ('Sweetbush');
//insert into subject (name) values ('Hoffmann''s Blacksnakeroot');
//insert into subject (name) values ('Ivory Coast Raphia Palm');
//insert into subject (name) values ('Schaereria Lichen');
//insert into subject (name) values ('Meehania');
//insert into subject (name) values ('Harvey''s Hawthorn');
//insert into subject (name) values ('Lewis Flax');
//insert into subject (name) values ('Rauiella Moss');
//insert into subject (name) values ('Guyandotte Beauty');
//insert into subject (name) values ('Graham''s Mimosa');
//insert into subject (name) values ('Gray Globemallow');
//insert into subject (name) values ('Field Locoweed');
//insert into subject (name) values ('Sweet Pitcherplant');
//insert into subject (name) values ('Slender Sensitive Pea');
//insert into subject (name) values ('Sour Orange');
//insert into subject (name) values ('Sonora Draba');
//insert into subject (name) values ('Amphidium Moss');

//select* from subject
//select * from student


//CREATE TABLE "archive"
//(
//    id bigserial NOT NULL,
//    table_name character varying(40) NOT NULL,
//    row_id bigint NOT NULL,
//old_data text,
//    new_data text
//);

//1-------------------------------------------------------------------------------- -

//CREATE FUNCTION student_trigger()
//    RETURNS trigger
//    LANGUAGE 'plpgsql'
//AS $$
//begin
//  insert into archive ("table_name","row_id", "old_data", "new_data")
//  values ('student', OLD.id, OLD, NEW);
//return new;
//end
//$$


//CREATE OR REPLACE TRIGGER student_triggers
//    BEFORE UPDATE 
//    ON student
//    FOR EACH ROW
//    EXECUTE FUNCTION student_trigger();

//update student 
//set age = 25
//where id = 3;

//select* from archive

//2-----------------------------------------------------------------------------------

//CREATE FUNCTION group_trigger()
//    RETURNS trigger
//    LANGUAGE 'plpgsql'
//AS $$
//begin
//	insert into archive ("table_name","row_id","old_data", "new_data")
//	values ('group', OLD.id, OLD, NEW);
//return new;
//end
//$$;

//CREATE OR REPLACE TRIGGER group_tringers
//    BEFORE UPDATE 
//    ON student_of_group
//    FOR EACH ROW
//    EXECUTE FUNCTION group_trigger();

//select* from student_of_group

//update student_of_group
//set count = 7
//where id = 1

//select * from student_of_group
//select * from archive

//3-----------------------------------------------------------------

//CREATE FUNCTION subject_trigger()
//    RETURNS trigger
//    LANGUAGE 'plpgsql'
//AS $$
//begin
//	insert into archive ("table_name","row_id", "old_data", "new_data")
//	values ('subject', OLD.id, OLD, NEW);
//return new;
//end
//$$;

//CREATE OR REPLACE TRIGGER subject_tringers
//    BEFORE UPDATE 
//    ON subject
//    FOR EACH ROW
//    EXECUTE FUNCTION subject_trigger();


//update subject
//set name = 'Pitcherplant'
//where name = 'Dwarf Hesperochiron'

//select * from archive
//select * from subject

//Ustoz bu uy ishida hatolar bilan olishorib charchab kettim lekin.
