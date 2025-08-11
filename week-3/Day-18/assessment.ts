// 1. Define the Contact interface
interface Contact {
  id: number;
  name: string;
  email: string;
  phone: string;
}

// 2. Implement the ContactManager class
class ContactManager {
  private contacts: Contact[] = [];

  // Add a new contact
  addContact(contact: Contact): void {
    const exists = this.contacts.some((c) => c.id === contact.id);
    if (exists) {
      console.error(
        `❌ Contact with ID ${contact.id} already exists. Please use a unique ID.`
      );
      return;
    }
    this.contacts.push(contact);
    console.log(`✅ Contact with ID ${contact.id} added successfully.`);
  }

  // View all contacts
  viewContacts(): Contact[] {
    if (this.contacts.length === 0) {
      console.warn("⚠ No contacts found.");
    }
    return this.contacts;
  }

  // Modify an existing contact
  modifyContact(id: number, updatedContact: Partial<Contact>): void {
    const contactIndex = this.contacts.findIndex((c) => c.id === id);
    if (contactIndex === -1) {
      console.error(`❌ Contact with ID ${id} does not exist. Cannot modify.`);
      return;
    }
    this.contacts[contactIndex] = {
      ...this.contacts[contactIndex],
      ...updatedContact,
    };
    console.log(`✏️ Contact with ID ${id} modified successfully.`);
  }

  // Delete a contact
  deleteContact(id: number): void {
    const contactIndex = this.contacts.findIndex((c) => c.id === id);
    if (contactIndex === -1) {
      console.error(`❌ Contact with ID ${id} does not exist. Cannot delete.`);
      return;
    }
    this.contacts.splice(contactIndex, 1);
    console.log(`🗑️ Contact with ID ${id} deleted successfully.`);
  }
}

// 4. Testing the ContactManager functionality
const manager = new ContactManager();

// Adding contacts
manager.addContact({
  id: 1,
  name: "John Doe",
  email: "john@example.com",
  phone: "1234567890",
});
manager.addContact({
  id: 2,
  name: "Jane Smith",
  email: "jane@example.com",
  phone: "0987654321",
});
manager.addContact({
  id: 1,
  name: "Duplicate",
  email: "dup@example.com",
  phone: "0000000000",
}); // Test duplicate ID

// Viewing contacts
console.log("📋 All Contacts:", manager.viewContacts());

// Modifying a contact
manager.modifyContact(1, { phone: "1111111111" });

// Deleting a contact
manager.deleteContact(2);

// Trying to modify a non-existing contact
manager.modifyContact(5, { name: "Ghost" });

// Trying to delete a non-existing contact
manager.deleteContact(5);

// View contacts after operations
console.log("📋 Final Contacts:", manager.viewContacts());
