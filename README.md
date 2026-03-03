# PersonalScheduleManager

## 1. Mô tả

**PersonalScheduleManager** là phần mềm quản lý thời gian biểu cá nhân chạy trên console, cho phép người dùng tạo, theo dõi và điều chỉnh lịch trình công việc theo thời gian.

Hệ thống được thiết kế theo nguyên lý lập trình hướng đối tượng (OOP) và áp dụng các design pattern:

- Inheritance
- Polymorphism
- Abstraction
- Builder Pattern
- Repository Pattern

Dữ liệu được lưu trữ bằng cơ chế serialization/deserialization ra file JSON.

---

## 2. Chức năng chính

- Tạo, chỉnh sửa và xóa công việc
- Gán thời gian bắt đầu, thời gian kết thúc hoặc deadline
- Phân loại công việc theo loại (Task, Event, Reminder)
- Gán mức độ ưu tiên
- Đánh dấu trạng thái hoàn thành
- Hiển thị danh sách công việc theo ngày
- Tìm kiếm theo từ khóa
- Lưu và tải dữ liệu từ file JSON

---

## 3. Sơ đồ thiết kế

<img width="1120" height="777" alt="image" src="https://github.com/user-attachments/assets/5f1dfe13-5f8c-4cd4-99c5-a95c87ef90e1" />

Hệ thống được chia thành các layer:

- Presentation Layer  
  - ConsoleMenu  
  - InputHelper  

- Domain Layer  
  - ScheduleItem (abstract)  
  - TaskItem  
  - EventItem  
  - ReminderItem  
  - TimeRange  
  - Status (enum)  
  - Priority (enum)  

- Business Layer  
  - Schedule  
  - ScheduleService  
  - ScheduleValidator  

- Persistence Layer  
  - IScheduleRepository  
  - JsonScheduleRepository  

---

## 4. Thành viên

- Nguyễn Phước Thuần  
- Nguyễn Đặng Hòa Thuận  
- Bá Thành Chí Khang  
- Nguyễn Công Thành  

---

## 5. Phân công nhiệm vụ

### Nguyễn Đặng Hòa Thuận – UI và Input

Phụ trách:
- ConsoleMenu
- InputHelper
- Tích hợp Builder và Service

Công việc:
- Xây dựng menu
- Xử lý nhập liệu
- Gọi đúng service method

---

### Bá Thành Chí Khang – Domain Model

Phụ trách:
- ScheduleItem và các lớp kế thừa
- TimeRange
- Enum

Công việc:
- Cài đặt Display và GetTypeName
- Cài đặt IsValid và Overlaps
- Đảm bảo kế thừa đúng

---

### Nguyễn Phước Thuần – Business Logic

Phụ trách:
- Schedule
- ScheduleService
- ScheduleValidator

Công việc:
- Cài đặt các thao tác CRUD
- Kiểm tra xung đột thời gian
- Điều phối toàn bộ logic hệ thống

---

### Nguyễn Công Thành – Persistence và Builder

Phụ trách:
- IScheduleRepository
- JsonScheduleRepository
- TaskBuilder
- EventBuilder
- ReminderBuilder

Công việc:
- Serialize và Deserialize JSON
- Cài đặt fluent API cho Builder
- Đảm bảo Build trả về đúng object

---

## 6. Luồng hoạt động chính

1. Người dùng chọn chức năng từ ConsoleMenu  
2. ConsoleMenu sử dụng InputHelper để lấy dữ liệu  
3. Builder tạo ScheduleItem tương ứng  
4. ScheduleService:
   - Gọi ScheduleValidator để kiểm tra hợp lệ
   - Nếu hợp lệ thì thêm vào Schedule
5. Repository lưu dữ liệu xuống file JSON  

---
