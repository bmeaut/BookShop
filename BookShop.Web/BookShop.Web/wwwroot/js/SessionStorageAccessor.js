export function get(key) {
    var value = window.sessionStorage.getItem(key);
    return JSON.parse(value);
}

export function set(key, value) {
    window.sessionStorage.setItem(key, JSON.stringify(value));
}

export function clear() {
    window.sessionStorage.clear();
}

export function remove(key) {
    window.sessionStorage.removeItem(key);
}