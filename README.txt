1.起點

這是一個影片出租店用的程式，計算每一位客戶的消費金額並列印出樣單。
操作者告訴程式顧客租了那些影片、租期多長，程式便根據租貸時間和影片類型計算出費用。
影片分為三類：普通片、兒童片和新片。
除了計算費用，還要為顧客計算積分，積分會根據租片種類是否為新片而不同

2.評價

Customer裡的Statement()做的事情太多了，它做了很多原本應該由其他類完成的事情。
即便如此，這個程式還是能正常工作，但是複雜的系統很難找到修改點，程式設計師可能會犯錯引入bug。

重構第一個步驟是替要修改的程式碼建立一組可靠的測試環境。

3.分解並重組Statement()

找出邏輯泥團，很明顯的一個例子是switch語句，把它提煉到獨立的函數中(Alt + .)。
首先找出函數中的局部變數和參數，找到了兩個，each和thisAmount，前者並未被修改，後者會被修改。任何不會被修改的變數都可以被當成參數傳入新函數，至於被修改的變數需要格外小心。 
如果只有一個變數會被修改，就把它當成返回值。thisAmount是個是臨時變數，其值在每次循環起始處被設為0，並且switch語句之前不會改變，所以直接當成函數的返回值。

提取出來的新函數裡面的兩個變數each和thisAmount，為了讓程式能夠清楚表達自己的功能，所以分別改名為aRental和result。

4.搬移[金額計算]程式碼

觀察AmountFor()時發現使用了Rental類卻沒有使用Customer類的信息。絕大多數情況下函數應該放在它所使用的數據的所屬物件內，所以AmountFor()應該移到Rental類去。

5.提煉[常客積分計算]程式碼

積分的計算依影片種類而有不同，但是不像收費規則有那麼多變化。看來似乎有理由把積分責任放在Rental類身上。

6.去除臨時變數

過多的臨時變數會讓函數變得冗長。這裡有兩個臨時變數totalAmount和frequentRenterPoints，都是從Rental物件中獲取某個總量，且可能會設計新的函數(例如HtmlStatement()返回html格式的字串)來取得這兩個變數，所以打算建立查詢函數並減少原本函數程式碼來促成乾淨的設計。

7.取代與價格相關的條件邏輯

最好不要在另一個物件的屬性基礎上運用switch語句。如果不得不使用也應該在物件自己的數據上使用，而不是別人的數據上使用，這暗示Rental類的GetCharge()應該搬到Movie類裡面去。
Rental類的GetFrequentRenterPoints()根據影片類型而變化，所以也放到影片類型所屬的類中。


8.多型與繼承

為Movie建立Price類和Price的三個子類，每個都有自己的計費方法，這樣就可以用多型取代switch語句。











