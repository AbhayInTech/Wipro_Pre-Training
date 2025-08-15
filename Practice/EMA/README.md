# Event Management App (Angular)

## 📌 Project Description

The **Event Management App** is an Angular application that displays upcoming events, formats ticket prices, and highlights premium events.  
It demonstrates the use of:

- Angular **Components**
- **Custom Pipes**
- **Custom Directives**
- **Animations** for better user experience

---

## 🚀 Features

1. **Event List Component**

   - Displays events with Name, Date, Ticket Price, and Category.
   - Uses `*ngFor` to iterate over a list of events.

2. **Custom Pipe (`PriceFormatPipe`)**

   - Formats ticket prices into Indian currency format.
   - Example:
     - `500` → `₹500.00`
     - `1200` → `₹1,200.00`

3. **Custom Directive (`Highlight`)**

   - Highlights premium events (ticket price above ₹2000) with a light golden background.

4. **Animations**
   - Fade-in animation when events are loaded.

---

## 📂 Folder Structure

src/
├── app/
│ ├── components/
│ │ └── event-list/ # Event list component files
│ ├── pipes/
│ │ └── price-format-pipe.ts # Custom price format pipe
│ ├── directives/
│ │ └── highlight.ts # Custom directive for highlighting
│ ├── app.component.ts
│ ├── main.ts

---

## 🛠 Installation & Setup

### 1️⃣ Clone the Repository

git clone <your-repository-url>
cd EMA

### 2️⃣ Install Dependencies

npm install

### 3️⃣ Install Angular Animations (required for fadeIn effect)

npm install @angular/animations

### 4️⃣ Run the Application

ng serve

### 5️⃣ Open in Browser

Visit: http://localhost:4200

---

## 📜 Usage

- On loading, the **Event List** will display all upcoming events.
- Ticket prices are shown in formatted INR style.
- Events with ticket price > ₹2000 will have a highlighted background.
- Fade-in animation applies when rows are displayed.

---

## 📸 Example Output

| Event Name                   | Date        | Ticket Price | Category   |
| ---------------------------- | ----------- | ------------ | ---------- |
| Tech Innovators Conference   | 12-Sep-2025 | ₹3,500.00    | Conference |
| Creative Writing Workshop    | 05-Oct-2025 | ₹800.00      | Workshop   |
| Rock Music Concert           | 20-Nov-2025 | ₹2,500.00    | Concert    |
| AI & Machine Learning Summit | 02-Dec-2025 | ₹5,000.00    | Conference |

---

## 📌 Technologies Used

- **Angular** (Standalone Components)
- **TypeScript**
- **HTML5 / CSS3**
- **Angular Animations**

---

## 👨‍💻 Author

Abhay Rana
