export const addProductToCart = (state, product) => {
	product.quantity = 1;
	state.cart.push(product);
};

export const updateProductQuantity = (state, product) => {
	const index = state.cart.indexOf(product);
	let cartItem = state.cart[index];
	cartItem.quantity++;

	state.cart.splice(index, 1, Object.assign({}, cartItem));
};


/*
	This mutation is a simple case of calling the Array.splice function and passing it the 
	index argument as the position to start deleting from, and instructing it to only delete 
	a single item by passing 1 as the second parameter. 
	By modifying the cart array using the splice function, Vue can detect the change and react to it (refresh UI).
*/
export const removeProductFromCart = (state, index) => {
	state.cart.splice(index, 1);
};

//https://subscription.packtpub.com/book/application_development/9781788839464/6/ch06lvl1sec51/updating-cart-items