const url = "https://localhost:7228/Category/api";

async function fetchCategories() {
  const response = await fetch(url);
  if (!response.ok) console.log("network error");

  const categories = await response.json();

  const categoryList = document.getElementById("categories");
  categoryList.innerHTML = "";

  categories.forEach((category) => {
    const item = document.createElement("li");
    console.log(category);
    item.textContent = category.categoryName;
    categoryList.appendChild(item);
  });
}

fetchCategories();
