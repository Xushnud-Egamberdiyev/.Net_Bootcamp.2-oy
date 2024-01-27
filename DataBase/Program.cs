//--3.1-- > A
//select title from course
//where credits = 3 and dept_name = 'Comp. Sci.'

//--3.1 --> B
//-- TASK 3
//select   distinct student.ID
//from(student join takes using (ID))
//join(instructor join teaches using (ID))
//using (courseid,secid, semester, year)
//where instructor.name = 'Luo'

//--3.1 --> C
//select max(salary)
//from instructor

//--3.1 --> D
//select id, name
//from instructor
//where salary = (select max(salary) from instructor)


//--3.1 --> E
//select course_id, sec_id, count(ID)
//from section natural join takes 
//where semester = 'Autumn'
//and year= 2009
//group by course_id, sec_id

//--3.3 --> A
//update instructor
//set salary = salary * 1.10
//where dept_name = 'Comp. Sci.'

//--3.3 --> B
//delete from course
//where course_id not in 
//(select course_id from section)

//--3.3 --> C
//insert into instructor 
//select ID, name, dept_name, 10000
//from student 
//where tot_cred> 100