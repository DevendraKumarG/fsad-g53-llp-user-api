CREATE DATABASE IF NOT EXISTS `llp-dev`;
USE `llp-dev`;

CREATE TABLE `languages` (
  `language_id` INT AUTO_INCREMENT PRIMARY KEY,
  `name` VARCHAR(255) NOT NULL,
  `description` VARCHAR(255),
  `code` VARCHAR(10) NOT NULL
);

CREATE TABLE `media_type` (
  `media_type_id` INT AUTO_INCREMENT PRIMARY KEY,
  `name` VARCHAR(255) NOT NULL,
  `extension` VARCHAR(10) NOT NULL
);

CREATE TABLE `users` (
  `user_id` INT AUTO_INCREMENT PRIMARY KEY,
  `first_name` VARCHAR(255) NOT NULL,
  `last_name` VARCHAR(255) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `encrypted_password` VARCHAR(255) NOT NULL,
  `language_id` INT,
  `contact` VARCHAR(255),
  `address` VARCHAR(255),
  FOREIGN KEY (`language_id`) REFERENCES `languages` (`language_id`)
);

CREATE TABLE `language_sections` (
  `section_id` INT AUTO_INCREMENT PRIMARY KEY,
  `language_id` INT NOT NULL,
  `section_name` VARCHAR(255) NOT NULL,
  `description` VARCHAR(255),
  `media_type_id` INT,
  `s3_file_key` VARCHAR(255),
  `sequence` INT,
  FOREIGN KEY (`language_id`) REFERENCES `languages` (`language_id`),
  FOREIGN KEY (`media_type_id`) REFERENCES `media_type` (`media_type_id`)
);

CREATE TABLE `bookmarks` (
  `bookmark_id` INT AUTO_INCREMENT PRIMARY KEY,
  `user_id` INT NOT NULL,
  `language_id` INT NOT NULL,
  `section_id` INT NOT NULL,
  FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`),
  FOREIGN KEY (`language_id`) REFERENCES `languages` (`language_id`),
  FOREIGN KEY (`section_id`) REFERENCES `language_sections` (`section_id`)
);

CREATE TABLE `assessments` (
  `language_id` INT NOT NULL,
  `section_id` INT NOT NULL,
  `assessment_id` INT AUTO_INCREMENT PRIMARY KEY,
  `description` VARCHAR(255),
  `media_type_id` INT,
  `s3_file_key` VARCHAR(255),
  `sequence` INT,
  `attempts_allowed` INT,
  `pass_score` INT,
  FOREIGN KEY (`language_id`) REFERENCES `languages` (`language_id`),
  FOREIGN KEY (`section_id`) REFERENCES `language_sections` (`section_id`),
  FOREIGN KEY (`media_type_id`) REFERENCES `media_type` (`media_type_id`)
);

CREATE TABLE `results` (
 `result_id` INT AUTO_INCREMENT PRIMARY KEY,
  `user_id` INT NOT NULL,
  `assessment_id` INT NOT NULL,
  `attempts_count` INT,
  `score` INT,
  FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`),
  FOREIGN KEY (`assessment_id`) REFERENCES `assessments` (`assessment_id`)
);

-- Mock data
INSERT INTO `languages` (`name`, `description`, `code`) VALUES
('English', 'English Language', 'EN'),
('Spanish', 'Spanish Language', 'ES'),
('French', 'French Language', 'FR'),
('German', 'German Language', 'DE');

INSERT INTO `media_type` (`name`, `extension`) VALUES
('PDF', '.pdf'),
('Video', '.mp4'),
('Audio', '.mp3'),
('Json', '.json');

INSERT INTO `language_sections` (`language_id`, `section_name`, `description`, `media_type_id`, `s3_file_key`, `sequence`) VALUES
(1, 'Section A', 'Grammer', 2, '', 1),
(1, 'Section B', 'Vocabulary', 2, '', 2),
(1, 'Section C', 'Reading Comprehension', 2, '', 3),
(1, 'Section D', 'Listening Comprehension', 2, '', 4),
(2, 'Section A', 'Grammer', 2, '', 1),
(2, 'Section B', 'Vocabulary', 2, '', 2),
(2, 'Section C', 'Reading Comprehension', 2, '', 3),
(2, 'Section D', 'Listening Comprehension', 2, '', 4),
(3, 'Section A', 'Grammer', 2, '', 1),
(3, 'Section B', 'Vocabulary', 2, '', 2),
(3, 'Section C', 'Reading Comprehension', 2, '', 3),
(3, 'Section D', 'Listening Comprehension', 2, '', 4),
(4, 'Section A', 'Grammer', 2, '', 1),
(4, 'Section B', 'Vocabulary', 2, '', 2),
(4, 'Section C', 'Reading Comprehension', 2, '', 3),
(4, 'Section D', 'Listening Comprehension', 2, '', 4);

INSERT INTO `assessments` (`language_id`, `section_id`, `description`, `media_type_id`, `s3_file_key`, `sequence`, `attempts_allowed`, `pass_score`) VALUES
(1, 1, 'Grammer', 4, '', 1, 3, 70),
(1, 2, 'Vocabulary', 4, '', 2, 3, 70),
(1, 3, 'Reading Comprehension', 4, '', 3, 3, 70),
(1, 4, 'Listening Comprehension', 4, '', 4, 3, 70),
(2, 5, 'Grammer', 4, '', 1, 3, 70),
(2, 6, 'Vocabulary', 4, '', 2, 3, 70),
(2, 7, 'Reading Comprehension', 4, '', 3, 3, 70),
(2, 8, 'Listening Comprehension', 4, '', 4, 3, 70),
(3, 9, 'Grammer', 4, '', 1, 3, 70),
(3, 10, 'Vocabulary', 4, '', 2, 3, 70),
(3, 11, 'Reading Comprehension', 4, '', 3, 3, 70),
(3, 12, 'Listening Comprehension', 4, '', 4, 3, 70),
(4, 13, 'Grammer', 4, '', 1, 3, 70),
(4, 14, 'Vocabulary', 4, '', 2, 3, 70),
(4, 15, 'Reading Comprehension', 4, '', 3, 3, 70),
(4, 16, 'Listening Comprehension', 4, '', 4, 3, 70);
