# BatchRename
Link video: https://drive.google.com/file/d/1E20XeTE3zDqCfVLzSFYR2wYCv3iZRCYI/view?usp=sharing

Phần đã hoàn thành và làm thêm (xem video để hiểu thêm):

1. Phần chọn tệp tin và thư mục có 2 cách chọn: 
 - Chọn trực tiếp tệp tin hoặc thư mục muốn chọn.
 - Chọn thư mục để lấy các tệp tin hoặc thư mục con trong thư mục đó

2. Hiển thị danh sách các hành động để người dùng lựa chọn trong list view bên trái, có cài đặt giao diện đóng mở (thầy nói phần này cộng điểm nếu ai làm).
 - Các kiểu hành động với chuỗi được thêm và hiển thị trong combobox. 
 
3. Bấm Start Batch sẽ thực hiện hành động đổi tên, nếu trùng thì bỏ qua giữ lại tên cũ.
        Phần làm thêm: 
        - Trong phần danh sách file hay thư mục cần áp hành động, nếu muốn file nào cần thực hiện thì tick vào check box, còn không check thì sẽ không thực hiện.
        - Trên thanh header trong tab hiển thị thư mục hoặc tệp tin có ô check box, nếu muốn chọn hoặc bỏ chọn tất cả các tệp chỉ cần check vào checkbox.

4. Lưu các hành động dưới dạng preset trong thư mục Batch Methods và nạp lên để lựa chọn.

5. Các hành động thao tác với tệp : Replace, New Case, Fullname normalize có trong New Name, Move, Unique Name (GUID name - nằm trong New Name).

 Phần làm thêm: + Trong NewCase có thêm kí tự hoặc chữ số sau tên
	          + Có thêm các phương thức: Trim, Remove, Extension
				
6. Cho phép xem trước khi đổi tên, các button cài đặt đầy đủ

Lưu ý: 
	- Khi muốn chọn hay xóa phương thức, cần nhấp vào phần nội dung của phương thức mới có thể xóa hoặc chọn.
        - Button Refresh dùng để cập nhật lại combobox preset, nếu vừa lưu xong một preset, cần nhấn refresh để combobox cập nhật lại.
        - Các preset có đuôi mở rộng là ".brn", nếu chọn đuôi khác sẽ không mở.
      	- Khi lưu các preset "nên" lưu trong thư mục Batch Methods, mở ra cũng tương tự
	- Để tìm một từ để xóa trong chuỗi, ví dụ chuỗi  "myVideoyoutube.mp4", muốn xóa từ youtube trong chuỗi có 2 cách:
		+ Dùng Remove, nhập vị trí bắt đầu là 8, số kí tự cần xóa là 7
		+ Dùng Replace, trong ô Old Content nhập youtube, phần New Content để trống.
        - Để đổi tên mở rộng của một tệp, ta chọn phương thức Extension, nhập vào tên mở rộng muốn đổi vào Convert ví dụ: ".jpg" và nhập tên mở rộng muốn đổi vào To ví dụ:".png"
	   

             

	   


 

