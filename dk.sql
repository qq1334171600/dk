/*
 Navicat Premium Data Transfer

 Source Server         : 120.48.99.11
 Source Server Type    : MySQL
 Source Server Version : 50738
 Source Host           : 120.48.99.11:3306
 Source Schema         : dk

 Target Server Type    : MySQL
 Target Server Version : 50738
 File Encoding         : 65001

 Date: 24/10/2022 14:27:10
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for attendance
-- ----------------------------
DROP TABLE IF EXISTS `attendance`;
CREATE TABLE `attendance`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `attendance_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '考勤编号：dk_用户名_mac_时间',
  `stu_id` varchar(18) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '学生编号',
  `time` datetime(0) DEFAULT NULL COMMENT '考勤时间',
  `location` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '考勤地址，系统自动获得',
  `pic_url` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '考勤图片url，七牛云',
  `notes` varchar(1024) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '考勤备注',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `stu_id`(`stu_id`) USING BTREE,
  CONSTRAINT `stu_id` FOREIGN KEY (`stu_id`) REFERENCES `users` (`stu_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 10 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of attendance
-- ----------------------------
INSERT INTO `attendance` VALUES (5, 'dk_202200501240_F2-18-98-07-45-3E_2022-10-16/19-10-48', '202200501240', '2022-10-16 19:10:21', '江苏省盐城市盐都区潘黄街道兆泉路', 'http://7.zhangjian.link/dk/202200501240/2022-10-16/19-10-48.jpg', '数据库恢复速度可接受的开始计划');
INSERT INTO `attendance` VALUES (6, 'dk_202200501240_F2-18-98-07-45-3E_2022-10-16/19-11-04', '202200501240', '2022-10-16 19:10:21', '江苏省盐城市盐都区潘黄街道兆泉路', 'http://7.zhangjian.link/dk/202200501240/2022-10-16/19-11-04.jpg', '数据库恢复速度可接受的开始计划');
INSERT INTO `attendance` VALUES (7, 'dk_202200501240_F2-18-98-07-45-3E_2022-10-16/19-11-23', '202200501240', '2022-10-16 19:10:21', '江苏省盐城市盐都区潘黄街道兆泉路', 'http://7.zhangjian.link/dk/202200501240/2022-10-16/19-11-22.jpg', '数据库恢复速度可接受的开始计划1111');
INSERT INTO `attendance` VALUES (8, 'dk_202200501240_F2-18-98-07-45-3E_2022-10-16/19-11-57', '202200501240', '2022-10-16 19:10:21', '江苏省盐城市盐都区潘黄街道兆泉路', 'http://7.zhangjian.link/dk/202200501240/2022-10-16/19-11-57.jpg', '数据库恢复速度可接受的开始计划1111');
INSERT INTO `attendance` VALUES (9, 'dk_202200501240_F2-18-98-07-45-3E_2022-10-17/13-15-35', '202200501240', '2022-10-17 13:14:09', '江苏省盐城市建湖县近湖街道双湖路', 'http://7.zhangjian.link/dk/202200501240/2022-10-17/13-15-35.jpg', '111');

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stu_id` varchar(18) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `stu_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `stu_password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `stu_phone` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `mac` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `course_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `is_online` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `stu_id`(`stu_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 27 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES (26, '202200501240', '张健', '5845331588', '17601542514', 'F2-18-98-07-45-3E', '1', '0');

SET FOREIGN_KEY_CHECKS = 1;
